using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testLogin.Models;


namespace testLogin.Controllers
{
    [Authorize]
    public class FloorplansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Floorplans
        public ActionResult Index()
        {
            try
            {
                var resID = db.Restaurant.SqlQuery("SELECT * FROM bourguestMob.Restaurant WHERE Email = @email", new SqlParameter("@email", User.Identity.Name)).First();
                return View(db.Floorplan.SqlQuery("SELECT * FROM bourguestMob.Floorplan WHERE restID = @restID", new SqlParameter("@restID", resID.id)));
            }
            catch (Exception e)
            {
                return RedirectToAction("Create", "Restaurants");
            }
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
            floorplan.id = 1;
            try
            {
                floorplan.id = db.Floorplan.OrderByDescending(t => t.id).FirstOrDefault().id + 1;
            }
            catch (NullReferenceException e)
            {
            }
            var resID = db.Restaurant.SqlQuery("SELECT * FROM bourguestMob.Restaurant WHERE Email = @email", new SqlParameter("@email", User.Identity.Name)).First();
            floorplan.restID = resID.id;
            if (ModelState.IsValid)
            {
                db.Floorplan.Add(floorplan);
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }


        }

        // GET: Floorplans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Floorplan floorplan = db.Floorplan.Find(id);
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
        public ActionResult Edit([Bind(Include = "id,planName,active,width,height,numObjects, restID")] Floorplan floorplan)
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
            Floorplan floorplan = db.Floorplan.Find(id);
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


            Floorplan floorplan = db.Floorplan.Find(id);

            List<Bookings> bookings = db.Bookings.SqlQuery("SELECT * FROM bourguestMob.Bookings  WHERE restID = @rID ", new SqlParameter("@rID", floorplan.restID)).ToList();
            if (bookings.Count == 0)
            {
                db.Floorplan.Remove(floorplan);
                List<tableObject> tab = db.tableObject.SqlQuery("SELECT * FROM bourguestMob.tableObject WHERE floorplanID = @planID", new SqlParameter("@planID", id)).ToList();
                tab.ForEach(r => db.tableObject.Remove(r));
                db.SaveChanges();
            }
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
