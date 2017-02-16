using System.Data.Entity;

namespace Customers
{
    public class PracticeDBEntities : DbContext
    {
        public PracticeDBEntities() : base()
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}
