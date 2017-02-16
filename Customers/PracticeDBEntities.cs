using System.Data.Entity;

namespace Models
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
