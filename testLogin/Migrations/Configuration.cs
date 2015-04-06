namespace testLogin.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using testLogin.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<testLogin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(testLogin.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var restaurants = new List<Restaurant>
             {
                new Restaurant{id=1,restaurantName="Good Fellas Pizza Pan",latitude=53.482239,longitude=-6.3329,wheelchair=true,vegetarian=true,type1="Italian",type2="Portuguese", type3="Pizza", phoneNum="225392945", openClose="9 to late",bio="Amazing Italian food from Don Corleone", Email="mark.lordan@me.com"},
                new Restaurant{id=2,restaurantName="Pita Pan Pita Breadsticks",latitude=53.25834,longitude=-6.64212, wheelchair=false,vegetarian=true,type1="Asian",type2="Pizza", type3="Traditional", phoneNum="5843839", openClose="9 to 5",bio="A nice bitta pita bread is always good",Email="robert_kenny@outlook.com"},
                new Restaurant{id=3,restaurantName="Thai Tanic",latitude=53.42249,longitude=-6.434329, wheelchair=false,vegetarian=false,type1="American",type2="Portuguese", type3="Pizza", phoneNum="225392945", openClose="9 to late",bio="Wok fried everything",Email="thomasmurphy21@gmail.com"},
                new Restaurant{id=4, restaurantName ="Aussie Outback", latitude=53.286374, longitude=-6.375107, wheelchair=true, vegetarian=false, type1="Healthy Option", phoneNum="5893923", openClose="6 to 11", bio="Aussie Outback BBQ food stuff", Email="aussieoutback@gmail.com" },
                new Restaurant{id=5, restaurantName ="Tamaras", latitude=53.286228, longitude=-6.376164, wheelchair=true,vegetarian=true,type1="Indian", type3="Pizza", phoneNum="59339", openClose="4 to 8", bio= "Tamara's bread, today", Email="tamaras@gmail.com"},
                new Restaurant{id=6, restaurantName="The Lemongrass", latitude=53.285983, longitude=-6.450154, wheelchair=true,vegetarian=true, type1="Something Different", type2="Pizza", phoneNum="2291", openClose="5 to 10", bio="Expensive and overpriced fiery food", Email="lemongrass@eircom.net"},
                new Restaurant{id=7, restaurantName="Niamh's Kitchen", latitude=53.286374, longitude=-6.375106, wheelchair=false,vegetarian=true,type1="Traditional",phoneNum="44554", openClose="4-9", bio="Food's ok, not great", Email="mark.lordan@email.com"}
             };
            restaurants.ForEach(r => context.Restaurant.AddOrUpdate(r));
            context.SaveChanges();

            var floorplan = new List<Floorplan>
             {
                new Floorplan{id=1,height=5,width=5,numObjects=3, restID = 1},
                new Floorplan{id=2,height=5,width=5,numObjects=5, restID=7},
                new Floorplan{id=3,height=5,width=5,numObjects=6, restID=7}
             };
            floorplan.ForEach(r => context.Floorplan.AddOrUpdate(r));
            context.SaveChanges();

            var tableObjects = new List<tableObject>
             { //objType, 0= chair, 1= square table, 2 = stool, 3 = round table
                new tableObject{id=1,xcoord=0,ycoord=0,objType=0,available=true,floorplanID=1},
                new tableObject{id=2,xcoord=1,ycoord=0,objType=1,available=true,floorplanID=1},
                new tableObject{id=3,xcoord=2,ycoord=0,objType=0,available=true,floorplanID=1},
                new tableObject{id=4,xcoord=0,ycoord=0,objType=0,available=true,floorplanID=2},
                new tableObject{id=5,xcoord=1,ycoord=3,objType=1,available=true,floorplanID=2},
                new tableObject{id=6,xcoord=0,ycoord=2,objType=0,available=true,floorplanID=2},
                new tableObject{id=7,xcoord=3,ycoord=2,objType=0,available=true,floorplanID=2},
                new tableObject{id=8,xcoord=3,ycoord=3,objType=0,available=true,floorplanID=2},
                new tableObject{id=9,xcoord=0,ycoord=0,objType=0,available=true,floorplanID=3},
                new tableObject{id=10,xcoord=1,ycoord=0,objType=0,available=true,floorplanID=3},
                new tableObject{id=11,xcoord=1,ycoord=3,objType=1,available=true,floorplanID=3},
                new tableObject{id=12,xcoord=0,ycoord=2,objType=0,available=true,floorplanID=3},
                new tableObject{id=13,xcoord=2,ycoord=2,objType=0,available=true,floorplanID=3},
                new tableObject{id=14,xcoord=3,ycoord=3,objType=0,available=true,floorplanID=3}
             };
            tableObjects.ForEach(r => context.tableObject.AddOrUpdate(r));
            context.SaveChanges();

            var booking = new Bookings{id=1, numTables=1, userID = "mark.lordan@gmail.com"};
            context.Bookings.AddOrUpdate(booking);
            context.SaveChanges();
            var tabBooking = new tableObjectBookings{id=1, day = 30, month =3, year=2015, tabObjID=5, time=1700, depart=1900};
            context.tableObjectBookings.AddOrUpdate(tabBooking);
            context.SaveChanges();
            var user = new UsersTable { id = "mark.lordan@gmail.com", password = "password" };
            context.UsersTable.AddOrUpdate(user);
            var userReviews = new List<UserReviews>{
                new UserReviews{id=1, userID="fake@review.net", restID="7"},
                new UserReviews{id=2, userID="fake@review2.net", restID="7"},
                new UserReviews{id=3, userID="fake@review3.net", restID="7"},
                new UserReviews{id=4, userID="fake@review.net", restID="4"},
                new UserReviews{id=5, userID="fake@review.net", restID="5"}
            };
            var reviews = new List<Reviews>{
                new Reviews{id=1, numReviews=3, rating=5, reviews=15, restID=7},
                new Reviews{id=2, numReviews=1, rating=4, reviews=4, restID=4},
                new Reviews{id=3, numReviews=1, rating=3, reviews=3, restID=5}
            };
            userReviews.ForEach(r => context.UserReviews.AddOrUpdate(r));
            context.SaveChanges();
            context.SaveChanges();
        }
    }
}
