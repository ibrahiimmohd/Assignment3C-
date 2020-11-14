﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;

namespace Assignment3.Models
{
    public class DBHelperContext : DbContext
    {
        public DBHelperContext() : base("Assignment3_db")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DBHelperContext>());

            //Database.SetInitializer(new AssignDbIntializer());
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Planet> Planets { get; set; }

    }
}
