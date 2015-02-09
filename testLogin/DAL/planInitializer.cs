using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using testLogin.Models;

namespace testLogin.DAL
{
    public class planInitializer :System.Data.Entity. DropCreateDatabaseIfModelChanges<planContext>
    {
        protected override void Seed(planContext context) 
        {
            //var restaurants = new List<Restaurant>
            //{
            //    new Restaurant{restaurantID=1,restaurantName="Good Fellas Pizza Pies",latitude=-6.42,longitude=53.28,wheelchair=true,vegetarian=true,type="Italian",bio="Amazing Italian food from Don Corleone", Email="mark.lordan@me.com"},
            //    new Restaurant{restaurantID=2,restaurantName="Pita Pan",latitude=-6.25,longitude=53.34, wheelchair=false,vegetarian=true,type="Café",bio="A nice bitta pita bread is always good",Email="robert_kenny@outlook.com"},
            //    new Restaurant{restaurantID=3,restaurantName="Thai Tanic",latitude=-6.48,longitude=53.29, wheelchair=false,vegetarian=false,type="Thai",bio="Wok fried everything",Email="thomasmurphy21@gmail.com"}
            //};
            //restaurants.ForEach(r => context.Restaurants.Add(r));
            //context.SaveChanges();

            //var floorplan = new List<Floorplan>
            //{
            //    new Floorplan{FloorplanID=1,height=5,width=5,numObjects=10}
            //};
            //floorplan.ForEach(r => context.Floorplans.Add(r));
            //context.SaveChanges();

            //var tableObjects = new List<tableObject>
            //{ //objType, 0= chair, 1= square table, 2 = stool, 3 = round table
            //    new tableObject{tableObjectID=1,xcoord=0,ycoord=0,objType=0,available=true,planID=1},
            //    new tableObject{tableObjectID=2,xcoord=1,ycoord=0,objType=1,available=true,planID=1},
            //    new tableObject{tableObjectID=3,xcoord=2,ycoord=0,objType=0,available=true,planID=1},
            //};
            //tableObjects.ForEach(r => context.tableObjects.Add(r));
            //context.SaveChanges();
        }
    }
}