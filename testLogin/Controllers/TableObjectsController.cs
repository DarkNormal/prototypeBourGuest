using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testLogin.DAL;
using testLogin.Models;

namespace testLogin.Controllers
{
    public class tableObjectsController : Controller
    {
        private planContext db = new planContext();

        // GET: tableObjects
        public ActionResult Index()
        {
            return View(db.tableObjects.ToList());
        }

        // GET: tableObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableObject tableObject = db.tableObjects.Find(id);
            if (tableObject == null)
            {
                return HttpNotFound();
            }
            return View(tableObject);
        }
        // GET: tableObjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tableObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void Create(List<tableObject> newObjects)
        {
            int floorplanID = db.Floorplans.OrderByDescending(t => t.FloorplanID).FirstOrDefault().FloorplanID + 1;
            for (int i = 0; i < newObjects.Count; i++)
            {
                newObjects[i].FloorplanID = floorplanID;
            }

            var model = new tableObject();
            if (ModelState.IsValid)
            {
                newObjects.ForEach(r => db.tableObjects.Add(r));
                //db.tableObjects.Add(newObjects);
                db.SaveChanges();
            }
        }
        //public ActionResult Create(tableObject newObjects)
        //{
        //    var model = new tableObject();
        //    if (ModelState.IsValid)
        //    {
        //        db.tableObjects.Add(newObjects);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: tableObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableObject tableObject = db.tableObjects.Find(id);
            if (tableObject == null)
            {
                return HttpNotFound();
            }
            return View(tableObject);
        }

        // POST: tableObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tableObjectID,xcoord,ycoord,objType,available,FloorplanID")] tableObject tableObject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableObject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableObject);
        }

        // GET: tableObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableObject tableObject = db.tableObjects.Find(id);
            if (tableObject == null)
            {
                return HttpNotFound();
            }
            return View(tableObject);
        }

        // POST: tableObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableObject tableObject = db.tableObjects.Find(id);
            db.tableObjects.Remove(tableObject);
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
