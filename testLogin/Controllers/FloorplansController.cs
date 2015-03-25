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
    public class FloorplansController : Controller
    {
        private planContext db = new planContext();

        // GET: Floorplans
        public ActionResult Index()
        {
            return View(db.Floorplans.ToList());

        }

        // GET: Floorplans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floorplan floorplan = db.Floorplans.Find(id);
            if (floorplan == null)
            {
                return HttpNotFound();
            }
            return View(floorplan);
        }
        

        // GET: Floorplans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Floorplans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Floorplan floorplan)
        {
            floorplan.id = db.Floorplans.OrderByDescending(t => t.id).FirstOrDefault().id + 1;
            if (ModelState.IsValid)
            {
                db.Floorplans.Add(floorplan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(floorplan);
        }

        // GET: Floorplans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floorplan floorplan = db.Floorplans.Find(id);
            if (floorplan == null)
            {
                return HttpNotFound();
            }
            return View(floorplan);
        }

        // POST: Floorplans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FloorplanID,height,width,numObjects")] Floorplan floorplan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(floorplan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(floorplan);
        }

        // GET: Floorplans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floorplan floorplan = db.Floorplans.Find(id);
            if (floorplan == null)
            {
                return HttpNotFound();
            }
            return View(floorplan);
        }

        // POST: Floorplans/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Floorplan floorplan = db.Floorplans.Find(id);
            db.Floorplans.Remove(floorplan);
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
