using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testLogin.DAL;
using testLogin.Models;

namespace testLogin.Controllers
{
    public class TableObjectsController : Controller
    {


        private planContext db = new planContext();
        [HttpPost]
        public ActionResult NewMessage(tableObject[] newObjects , int id)
        {
            //id in this case is Floorplan ID
            for (int i = 0; i < newObjects.Length; i++)
            {
                if (newObjects[i] != null)
                {
                    db.tableObjects.Add(newObjects[i]);
                }
            }
            db.SaveChanges();
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
    }
}