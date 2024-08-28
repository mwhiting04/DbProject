namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomPerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomPersons",
                c => new
                    {
                        CustomPersonID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        EmailPromotion = c.Int(nullable: false),
                        PersonType = c.String(),
                        NameStyle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomPersonID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomPersons");
        }
    }
}
