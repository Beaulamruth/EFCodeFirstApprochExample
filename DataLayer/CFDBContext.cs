using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//using EFCodeFirstApprochExample.Migrations;
using DomainModels;

namespace DataLayer
{
    public class CFDBContext:DbContext
    {
        public CFDBContext() : base("MyConnectionString")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFDBContext, Configuration>());
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
