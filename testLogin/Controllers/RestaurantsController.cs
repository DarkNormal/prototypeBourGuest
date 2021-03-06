﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using testLogin.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace testLogin.Controllers
{
    [Authorize]
    public class RestaurantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.Restaurant.SqlQuery("SELECT * FROM bourguestMob.Restaurant WHERE Email = @email", new SqlParameter("@email", User.Identity.Name)));
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,restaurantName,latitude,longitude,wheelchair,vegan,wifi, type1,type2,type3,openClose,bio, phoneNum,appImage")] Restaurant restaurant, HttpPostedFileBase fileToUpload)
        {
            restaurant.Email = User.Identity.Name;
            restaurant.restaurantName = restaurant.restaurantName.ToLower();
            if (ModelState.IsValid)
            {
                if (fileToUpload != null) //if they uploaded an image, skip if null
                {
                    try
                    {
                        string accountName = "bourguestblob";
                        string accoutnKey = "k6cRVklwaada5k3EXVBE4219ESoTLF1yKzZPBwx0dGY1OWk7WSoR3VDPgpoXj0rSangBPDz9fdQaUY3j3jNIEw==";
                        StorageCredentials creds = new StorageCredentials(accountName, accoutnKey);
                        CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                        CloudBlobClient client = account.CreateCloudBlobClient();
                        CloudBlobContainer sampleContainer = client.GetContainerReference("images");
                        if (sampleContainer.CreateIfNotExists())
                        {
                            var permissions = sampleContainer.GetPermissions();
                            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                            sampleContainer.SetPermissions(permissions);
                        }

                        string pic = System.IO.Path.GetFileName(fileToUpload.FileName);
                        string path = System.IO.Path.Combine(
                                              Server.MapPath("~/Content/Images"), pic);
                        fileToUpload.SaveAs(path);
                        string uniqueBlobName = string.Format("images/image_{0}{1}",
                            Guid.NewGuid().ToString(), Path.GetExtension(pic));
                        CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(uniqueBlobName);
                        using (Stream file = System.IO.File.OpenRead(path))
                        {
                            blob.UploadFromStream(file);
                        }
                        string bloburi = blob.Uri.ToString();
                        restaurant.appImage = bloburi;
                        //temporarily store image in webiste conent folder, but delete immediately
                        //once blob has been created and stored
                        System.IO.File.Delete(path);
                        db.Restaurant.Add(restaurant);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    return View(restaurant);
                }
                

                // after successfully uploading redirect the user
                return RedirectToAction("Index", "Restaurants");
            }
            //ModelState.isValid false return
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,restaurantName,latitude,longitude,wheelchair,vegan,wifi, type1,type2,type3,openClose,bio, phoneNum,appImage")] Restaurant restaurant, HttpPostedFileBase fileToUpload)
        {
            restaurant.Email = User.Identity.Name;
            restaurant.restaurantName = restaurant.restaurantName.ToLower();
            if (ModelState.IsValid)
            {
                if (fileToUpload != null)
                {
                    try
                    {
                        string accountName = "bourguestblob";
                        string accoutnKey = "k6cRVklwaada5k3EXVBE4219ESoTLF1yKzZPBwx0dGY1OWk7WSoR3VDPgpoXj0rSangBPDz9fdQaUY3j3jNIEw==";
                        StorageCredentials creds = new StorageCredentials(accountName, accoutnKey);
                        CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                        CloudBlobClient client = account.CreateCloudBlobClient();
                        CloudBlobContainer sampleContainer = client.GetContainerReference("images");
                        if (sampleContainer.CreateIfNotExists())
                        {
                            var permissions = sampleContainer.GetPermissions();
                            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                            sampleContainer.SetPermissions(permissions);
                        }


                        if (fileToUpload != null)
                        {

                            string pic = System.IO.Path.GetFileName(fileToUpload.FileName);
                            string path = System.IO.Path.Combine(
                                                  Server.MapPath("~/Content/Images"), pic);
                            fileToUpload.SaveAs(path);
                            string uniqueBlobName = string.Format("images/image_{0}{1}",
                                Guid.NewGuid().ToString(), Path.GetExtension(pic));
                            CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(uniqueBlobName);
                            using (Stream file = System.IO.File.OpenRead(path))
                            {
                                blob.UploadFromStream(file);
                            }
                            string bloburi = blob.Uri.ToString();
                            restaurant.appImage = bloburi;

                            System.IO.File.Delete(path);



                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurant.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Bookings> bookings = db.Bookings.SqlQuery("SELECT * FROM bourguestMob.Bookings  WHERE restID = @rID ", new SqlParameter("@rID", id)).ToList();
            if (bookings.Count != 0)
            {
                bookings.ForEach(r => db.Bookings.Remove(r));
            }
                List<int> planIDlist = new List<int>();
                Restaurant restaurant = db.Restaurant.Find(id);
                List<Floorplan> floorplan = db.Floorplan.SqlQuery("SELECT * FROM bourguestMob.Floorplan  WHERE restID = @rID ", new SqlParameter("@rID", id)).ToList();
                for (int i = 0; i < floorplan.Count; i++)
                {
                    planIDlist.Add(floorplan[i].id);
                }

                floorplan.ForEach(r => db.Floorplan.Remove(r));
                db.SaveChanges();
                for (int i = 0; i < planIDlist.Count; i++)
                {
                    int tabParam = planIDlist[i];
                    List<tableObject> tab = db.tableObject.SqlQuery("SELECT * FROM bourguestMob.tableObject WHERE floorplanID = @planID", new SqlParameter("@planID", tabParam)).ToList();
                    tab.ForEach(r => db.tableObject.Remove(r));
                    db.SaveChanges();
                }
                db.Restaurant.Remove(restaurant);
                db.SaveChanges();

            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
