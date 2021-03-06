// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WareHouseDb.WareHouseDateBaseContext;

namespace WareHouseDB.Migrations
{
    [DbContext(typeof(WareHouseDBContext))]
    partial class WareHouseDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WareHouseDB.Entities.DateTimeForJobsAmountCounter", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountDailyAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CurrentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("AmountCount");
                });

            modelBuilder.Entity("WareHouseDb.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SellPrice")
                        .HasColumnType("float");

                    b.Property<double>("StartPrice")
                        .HasColumnType("float");

                    b.Property<string>("Warehouse")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WareHouseDb.Entities.Requisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("VehicleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Requisites");
                });

            modelBuilder.Entity("WareHouseDb.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("СurrentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("WareHouseDb.Entities.Requisite", b =>
                {
                    b.HasOne("WareHouseDb.Entities.Product", "Product")
                        .WithOne("Requisites")
                        .HasForeignKey("WareHouseDb.Entities.Requisite", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WareHouseDb.Entities.Status", "Status")
                        .WithMany("Requisites")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("WareHouseDb.Entities.Product", b =>
                {
                    b.Navigation("Requisites");
                });

            modelBuilder.Entity("WareHouseDb.Entities.Status", b =>
                {
                    b.Navigation("Requisites");
                });
#pragma warning restore 612, 618
        }
    }
}
