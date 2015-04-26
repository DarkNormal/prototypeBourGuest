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
                new Restaurant{id=1,restaurantName="wei kee restaurant",latitude=53.2883259,
                    longitude=-6.3633057,wheelchair=true,vegan=true,wifi=false,type1="Chinese",type2="Thai", 
                    phoneNum="01 463 0960", openClose="2 p.m. - 11.30 p.m.",bio="Oriental Chinese and Thai restaurant", 
                    Email="weikeerestaurant@gmail.com", appImage="https://bourguestblob.blob.core.windows.net/images/weikee.jpg"},
                new Restaurant{id=2,restaurantName="the new leaf",latitude=53.2883183,
                    longitude=-6.3639025, wheelchair=true,vegan=true,wifi=false,type1="Chienese", 
                    phoneNum="01 463 0848", openClose="4 p.m. - 11 p.m.",bio="Traditional Chinese cuisine",
                    Email="theleafrestaurant@gmail.com", appImage="https://bourguestblob.blob.core.windows.net/images/leaf.gif"},
                new Restaurant{id=3,restaurantName="gin thai",latitude=53.2859043,
                    longitude=-6.3665606, wheelchair=true,vegan=true,wifi=true,type1="Thai", 
                    phoneNum="01 4585008", openClose="5 p.m. - late",bio="Ginthai, Modern Thai cuisine and cocktail lounge located at The Plaza Hotel Complex, Belgard Road, welcomed its first customers on July 27th 2013, to an evening of cocktails and Thai and Asian gourmet bites in a truly unique oriental setting.",
                    Email="info@ginthai.com", appImage="https://bourguestblob.blob.core.windows.net/images/xgin_thai_17website.jpg.pagespeed.ic.hL10XuSzvH.jpg"},
                new Restaurant{id=4, restaurantName ="aussie outback", latitude=53.286374, 
                    longitude=-6.375107, wheelchair=true, vegan=false,wifi=false, type1="Healthy Option", 
                    phoneNum="5893923", openClose="6 p.m. - 11 p.m.", bio="Ireland's Top Australian Themed BBQ Restaurant, with BBQ style slow-roasted meals served daily", 
                    Email="aussieoutback@gmail.com", appImage="https://bourguestblob.blob.core.windows.net/images/images/image_7f5fd5e1-cdc2-4c07-ba6d-1e887eabd08e.gif" },
                new Restaurant{id=5, restaurantName ="tamaras", latitude=53.286228, 
                    longitude=-6.376164, wheelchair=true,vegan=true,wifi=true,type1="Indian", 
                    type3="Pizza", phoneNum="59339", openClose="4 p.m. - 8 p.m.", bio= "Tamara's bread, today", 
                    Email="tamaras@gmail.com" , appImage="https://bourguestblob.blob.core.windows.net/images/images/image_3d3c3eac-b46f-42e3-85df-8d457395020f.jpg"},
                new Restaurant{id=6, restaurantName="the lemongrass", latitude=53.285973, 
                    longitude=-6.450133, wheelchair=true,vegan=true, wifi=true, type1="Thai", type2="Chinese", 
                    phoneNum="(01) 458 8193", openClose="5 p.m. - 11 p.m.", bio="Expensive and overpriced fiery food", 
                    Email="lemongrass@eircom.net", appImage="https://bourguestblob.blob.core.windows.net/images/lemongrass.jpg"},
                new Restaurant{id=7, restaurantName="IT Tallaght restaurant", latitude=53.286374, 
                    longitude=-6.375106, wheelchair=false,vegan=true,wifi=false,type1="Traditional",
                    phoneNum="44554", openClose="4 p.m. - 10 p.m.", bio="Restaurant for testing purposes", 
                    Email="mark.lordan@gmail.com", appImage="https://bourguestblob.blob.core.windows.net/images/images/image_5d49b855-8d5c-4fe6-b20e-a27bd66ff36b.jpg"}
             };
            restaurants.ForEach(r => context.Restaurant.AddOrUpdate(r));
            context.SaveChanges();

            var floorplan = new List<Floorplan>
             {
                new Floorplan{id=1,height=5,width=5,numObjects=3, restID = 1, planName="Upstairs", active=true},
                new Floorplan{id=2,height=5,width=5,numObjects=5, restID=7, planName="Downstairs", active=true},
                new Floorplan{id=3,height=5,width=5,numObjects=6, restID=7, planName="Upstairs", active=false}
             };
            floorplan.ForEach(r => context.Floorplan.AddOrUpdate(r));
            context.SaveChanges();

            var tableObjects = new List<tableObject>
             { //objType, 0= chair, 1= square table, 2 = stool, 3 = round table
                new tableObject{id=1,xcoord=0,ycoord=0,objType=2,available=true,floorplanID=1},
                new tableObject{id=2,xcoord=1,ycoord=0,objType=6,available=true,floorplanID=1},
                new tableObject{id=3,xcoord=2,ycoord=0,objType=16,available=true,floorplanID=1},
                new tableObject{id=4,xcoord=0,ycoord=0,objType=22,available=true,floorplanID=2},
                new tableObject{id=5,xcoord=1,ycoord=3,objType=32,available=true,floorplanID=2},
                new tableObject{id=6,xcoord=0,ycoord=2,objType=4,available=true,floorplanID=2},
                new tableObject{id=7,xcoord=3,ycoord=2,objType=34,available=true,floorplanID=2},
                new tableObject{id=8,xcoord=3,ycoord=3,objType=22,available=true,floorplanID=2},
                new tableObject{id=9,xcoord=0,ycoord=0,objType=32,available=true,floorplanID=3},
                new tableObject{id=10,xcoord=1,ycoord=0,objType=16,available=true,floorplanID=3},
                new tableObject{id=11,xcoord=1,ycoord=3,objType=14,available=true,floorplanID=3},
                new tableObject{id=12,xcoord=0,ycoord=2,objType=6,available=true,floorplanID=3},
                new tableObject{id=13,xcoord=2,ycoord=2,objType=12,available=true,floorplanID=3},
                new tableObject{id=14,xcoord=3,ycoord=3,objType=24,available=true,floorplanID=3}
             };
            tableObjects.ForEach(r => context.tableObject.AddOrUpdate(r));
            context.SaveChanges();

            var booking = new Bookings { id = 1, numTables = 1, userID = "mark.lordan@gmail.com", numPeople = 4, day = 30, month = 3, year = 2015, restID = 7 };
            context.Bookings.AddOrUpdate(booking);
            context.SaveChanges();
            var tabBooking = new tableObjectBookings { id = 1, day = 30, month = 3, year = 2015, tabObjID = 5, time = 1700, depart = 1900 };
            context.tableObjectBookings.AddOrUpdate(tabBooking);
            context.SaveChanges();
            var user = new List<UsersTable>
            {
                new UsersTable{ id = "mark.lordan@gmail.com", password = "password", accountVerified = true },
                new UsersTable{ id = "robertkenny21@gmail.com", password = "password", accountVerified = true},
                new UsersTable{ id = "robert_kenny@outlook.com", password = "password", accountVerified = true}
            };
            user.ForEach(r => context.UsersTable.AddOrUpdate(r));
            context.SaveChanges();
            var userReviews = new List<UserReviews>{
                new UserReviews{id=1, userID="fake@review.net", restID="7"},
                new UserReviews{id=2, userID="fake@review2.net", restID="7"},
                new UserReviews{id=3, userID="fake@review3.net", restID="7"},
                new UserReviews{id=4, userID="fake@review.net", restID="4"},
                new UserReviews{id=5, userID="fake@review.net", restID="5"}
            };
            userReviews.ForEach(r => context.UserReviews.AddOrUpdate(r));
            context.SaveChanges();
            var reviews = new List<Reviews>{
                new Reviews{id=1, numReviews=3, rating=5, reviews=15, restID=7},
                new Reviews{id=2, numReviews=1, rating=4, reviews=4, restID=4},
                new Reviews{id=3, numReviews=1, rating=3, reviews=3, restID=5}
            };
            reviews.ForEach(r => context.Reviews.AddOrUpdate(r));
            context.SaveChanges();
        }
    }
}
