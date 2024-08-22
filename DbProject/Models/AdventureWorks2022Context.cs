using System.Data.Entity;

namespace DbProject.Models
{
    public class AdventureWorks2022Context : DbContext
    {
        public AdventureWorks2022Context() : base("name=AdventureWorks2022Context")
        {
        }

        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EmailAddressModel> EmailAddresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessEntity>()
                .ToTable("Person.BusinessEntity")
                .HasKey(be => be.BusinessEntityID);

            modelBuilder.Entity<Person>()
                .ToTable("Person.Person")
                .HasKey(p => p.BusinessEntityID)
                .HasRequired(p => p.BusinessEntity)
                .WithOptional(be => be.Person);

            //modelBuilder.Entity<EmailAddressModel>()
            //    .ToTable("Person.EmailAddress")
            //    .HasKey(e => new { e.EmailAddressID, e.BusinessEntityID });

            //modelBuilder.Entity<EmailAddressModel>()
            //    .HasRequired(e => e.BusinessEntity)
            //    .WithMany(be => be.EmailAddresses)
            //    .HasForeignKey(e => e.BusinessEntityID);

            //modelBuilder.Entity<EmailAddressModel>()
            //    .HasRequired(e => e.Person)
            //    .WithMany(p => p.EmailAddresses)
            //    .HasForeignKey(e => e.BusinessEntityID);

            base.OnModelCreating(modelBuilder);
        }
    }
}