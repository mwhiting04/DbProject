﻿namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomPersons", "Title", c => c.String(maxLength: 8));
            AlterColumn("dbo.CustomPersons", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CustomPersons", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomPersons", "LastName", c => c.String());
            AlterColumn("dbo.CustomPersons", "FirstName", c => c.String());
            AlterColumn("dbo.CustomPersons", "Title", c => c.String());
        }
    }
}
