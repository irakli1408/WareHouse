using Microsoft.EntityFrameworkCore;
using WareHouseDb.Entities;
using WareHouseDB.Entities;

namespace WareHouseDb.WareHouseDateBaseContext
{
    public class WareHouseDBContext : DbContext
    {
        public WareHouseDBContext(DbContextOptions<WareHouseDBContext> options) : base(options) { }

        public WareHouseDBContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Requisite> Requisites { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DateTimeForJobsAmountCounter> AmountCount { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisite>()
                 .HasOne<Product>(x => x.Product)
                 .WithOne(x => x.Requisites)
                 .HasForeignKey<Requisite>(x => x.ProductId);


            modelBuilder.Entity<Requisite>()
                .HasOne<Status>(x => x.Status)
                .WithMany(x => x.Requisites)
                .HasForeignKey(x => x.StatusId);

            modelBuilder.Entity<Product>()
               .HasIndex(x => x.ProductCode).IsUnique();

            modelBuilder.Entity<DateTimeForJobsAmountCounter>().
                Property(p => p.CurrentDate)
                .HasColumnType("date");
        }

    }
}
