﻿namespace EFCodeFirstApprochExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
    }
}
