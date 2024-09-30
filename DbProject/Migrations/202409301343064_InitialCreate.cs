namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomPersons",
                c => new
                    {
                        CustomPersonID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 8),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        EmailPromotion = c.Int(nullable: false),
                        PersonType = c.String(),
                        NameStyle = c.Boolean(nullable: false),
                        PrimaryEmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.CustomPersonID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomPersons");
        }
    }
}
