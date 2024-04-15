using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VSG.Models
{
    public partial class VSGModel : DbContext
    {
        public VSGModel()
            : base("name=VSGModels")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetaill> OrderDetaills { get; set; }
        public virtual DbSet<Orderr> Orderrs { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Shoe_Service> Shoe_Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOptional(e => e.Shoe)
                .WithRequired(e => e.Category);

            modelBuilder.Entity<OrderDetaill>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Shoe_Service>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);
        }
    }
}
