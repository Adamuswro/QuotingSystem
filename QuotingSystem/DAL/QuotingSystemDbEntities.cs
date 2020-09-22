using QuotingSystem.Helpers;
using QuotingSystem.Models;
using System.Data.Entity;

namespace QuotingSystem.DAL
{
    public class QuotingSystemDbEntities : DbContext
    {
        public QuotingSystemDbEntities() : base("MyDb")
        {
        }

        public override int SaveChanges()
        {
            this.SyncObjectsStateBeforeSave();
            return base.SaveChanges();
        }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}