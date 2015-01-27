using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testLogin.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace testLogin.DAL
{
    public class planContext :DbContext
    {
        public planContext() : base("planContext") { 
        }


        public DbSet<Floorplan> Floorplans { get; set; }
        public DbSet<tableObject> tableObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}