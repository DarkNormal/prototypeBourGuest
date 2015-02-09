namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using testLogin.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<testLogin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(testLogin.Models.ApplicationDbContext context)
        {
            
        }
    }
}
