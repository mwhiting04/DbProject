using System.Data.Entity;

namespace DbProject.Models
{
    public class AdventureWorks2022Context : DbContext
    {
        public AdventureWorks2022Context() : base("name=AdventureWorks2022Context")
        {
        }

        public DbSet<CustomPerson> CustomPersons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}