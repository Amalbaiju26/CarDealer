namespace CarDealers.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<car> cars { get; set; }
        public virtual DbSet<carspec> carspecs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<car>()
                .HasMany(e => e.carspecs)
                .WithRequired(e => e.car)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<carspec>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<carspec>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<carspec>()
                .Property(e => e.milage)
                .HasPrecision(10, 2);

            modelBuilder.Entity<carspec>()
                .Property(e => e.model)
                .IsUnicode(false);
        }
    }
}
