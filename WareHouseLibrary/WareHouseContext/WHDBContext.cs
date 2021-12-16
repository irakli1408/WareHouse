using Microsoft.EntityFrameworkCore;
using WareHouseLibrary.Entities;

namespace WareHouseLibrary.WareHouseContext
{
    public class WHDBContext : DbContext
    {
        public WHDBContext(DbContextOptions options) : base(options) { }

        public WHDBContext() {  }

        public DbSet<Product> Products { get; set; }
        public DbSet<Requisite> Requisites { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DateTimeForJobsAmountCounter> AmountCount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisite>()
                .HasOne(x => x.Product)
                .WithMany(x => x.Requisites)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Requisite>()
                .HasOne(x => x.Status)
                .WithMany(x => x.Requisites)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<Product>()
               .HasIndex(x => x.ProductCode).IsUnique();
    }

        }


    }

