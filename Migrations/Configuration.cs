namespace EFCodeFirstApprochExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;
    using DomainModels;
    using DataLayer;
    public sealed class Configuration : DbMigrationsConfiguration<CFDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CFDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(
                new Brand() { BrandID = 1, BrandName = "Sony" },
                new Brand() { BrandID = 2, BrandName = "Samsung" }
                );
            context.Categories.AddOrUpdate(
                new Category() { CategoryID = 1, CategoryName = "Electronics" },
                new Category() { CategoryID = 2, CategoryName = "Home Appliance" }
                );

            context.Products.AddOrUpdate(
                new Product() { ProductID = 1, ProductName = "Mouse", CategoryID = 1, BrandID = 1, Price = 1000, Active = true, AvailabilityStatus = "InStock", DateOfPurchase = DateTime.Now }
                );
        }
    }
}
