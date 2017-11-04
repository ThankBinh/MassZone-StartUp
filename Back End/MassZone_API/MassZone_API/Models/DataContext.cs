using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MassZone_API.Models
{
    public class DataContext:DbContext
    {
        public virtual DbSet<User> Users { get; set; } 
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<CheckOut> CheckOuts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public DataContext():base("MassZoneDB")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new DataInitializer());
        }
    }
}