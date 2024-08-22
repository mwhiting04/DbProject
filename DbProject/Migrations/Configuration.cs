namespace DbProject.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DbProject.Models.AdventureWorks2022Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbProject.Models.AdventureWorks2022Context context)
        {
            // Seed initial data if needed
        }
    }

}
