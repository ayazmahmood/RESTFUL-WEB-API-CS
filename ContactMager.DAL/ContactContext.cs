namespace ContactMager.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContactContext : DbContext
    {
        public ContactContext()
            : base("name=ContactContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
