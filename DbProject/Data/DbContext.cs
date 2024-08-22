
using System.Data.Entity;

public class MyDbContext : DbContext
{
    // Constructor that calls the base class constructor with the connection string name
    public MyDbContext() : base("name=MyDbContext")
    {
    }

    // DbSets for your entities
    public DbSet<MyEntity> MyEntities { get; set; }
    // Add more DbSets as needed
}

public class MyEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Add more properties as needed
}
