namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigTwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Person.BusinessEntity",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BusinessEntityID);
            
            CreateTable(
                "Person.EmailAddress",
                c => new
                    {
                        EmailAddressID = c.Int(nullable: false),
                        BusinessEntityID = c.Int(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => new { t.EmailAddressID, t.BusinessEntityID })
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID, cascadeDelete: true)
                .ForeignKey("Person.Person", t => t.BusinessEntityID, cascadeDelete: true)
                .Index(t => t.BusinessEntityID);
            
            CreateTable(
                "Person.Person",
                c => new
                    {
                        BusinessEntityID = c.Int(nullable: false),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        EmailPromotion = c.Int(nullable: false),
                        PersonType = c.String(),
                        NameStyle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessEntityID)
                .ForeignKey("Person.BusinessEntity", t => t.BusinessEntityID)
                .Index(t => t.BusinessEntityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Person.EmailAddress", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.Person", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.EmailAddress", "BusinessEntityID", "Person.BusinessEntity");
            DropIndex("Person.Person", new[] { "BusinessEntityID" });
            DropIndex("Person.EmailAddress", new[] { "BusinessEntityID" });
            DropTable("Person.Person");
            DropTable("Person.EmailAddress");
            DropTable("Person.BusinessEntity");
        }
    }
}
