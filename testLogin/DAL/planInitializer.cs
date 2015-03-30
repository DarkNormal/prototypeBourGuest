using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using testLogin.Models;

namespace testLogin.DAL
{
    public class planInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<planContext>
    {
        protected override void Seed(planContext context) 
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant{id=1,restaurantName="Good Fellas Pizza Pan",latitude=53.482239,longitude=-6.3329,wheelchair=true,vegetarian=true,type1="Italian",type2="Portuguese", type3="Pizza", phoneNum="225392945", openClose="9 to late",bio="Amazing Italian food from Don Corleone", Email="mark.lordan@me.com"},
                new Restaurant{id=2,restaurantName="Pita Pan Pita Breadsticks",latitude=53.25834,longitude=-6.64212, wheelchair=false,vegetarian=true,type1="Asian",type2="Pizza", type3="Traditional", phoneNum="5843839", openClose="9 to 5",bio="A nice bitta pita bread is always good",Email="robert_kenny@outlook.com"},
                new Restaurant{id=3,restaurantName="Thai Tanic",latitude=53.42249,longitude=-6.434329, wheelchair=false,vegetarian=false,type1="American",type2="Portuguese", type3="Pizza", phoneNum="225392945", openClose="9 to late",bio="Wok fried everything",Email="thomasmurphy21@gmail.com"},
                new Restaurant{id=4, restaurantName ="Aussie Outback", latitude=53.286374, longitude=-6.375107, wheelchair=true, vegetarian=false, type1="Healthy Option", phoneNum="5893923", openClose="6 to 11", bio="Aussie Outback BBQ food stuff", Email="aussieoutback@gmail.com" },
                new Restaurant{id=5, restaurantName ="Tamaras", latitude=53.286228, longitude=-6.376164, wheelchair=true,vegetarian=true,type1="Indian", type3="Pizza", phoneNum="59339", openClose="4 to 8", bio= "Tamara's bread, today", Email="tamaras@gmail.com"},
                new Restaurant{id=6, restaurantName="The Lemongrass", latitude=53.285983, longitude=-6.450154, wheelchair=true,vegetarian=true, type1="Something Different", type2="Pizza", phoneNum="2291", openClose="5 to 10", bio="Expensive and overpriced fiery food", Email="lemongrass@eircom.net"}
            };
            restaurants.ForEach(r => context.Restaurants.Add(r));
            context.SaveChanges();

            var floorplan = new List<Floorplan>
            {
                new Floorplan{id=1,height=5,width=5,numObjects=3, restID = 1}
            };
            floorplan.ForEach(r => context.Floorplans.Add(r));
            context.SaveChanges();

            var tableObjects = new List<tableObject>
            { //objType, 0= chair, 1= square table, 2 = stool, 3 = round table
                new tableObject{id=1,xcoord=0,ycoord=0,objType=0,available=true,floorplanID=1},
                new tableObject{id=2,xcoord=1,ycoord=0,objType=1,available=true,floorplanID=1},
                new tableObject{id=3,xcoord=2,ycoord=0,objType=0,available=true,floorplanID=1},
            };
            tableObjects.ForEach(r => context.tableObjects.Add(r));
            context.SaveChanges();
        }
    }
}