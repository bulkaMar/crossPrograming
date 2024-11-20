using Microsoft.EntityFrameworkCore;
using LAB6.Models;
namespace LAB6
{
    public class CarServiceContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceBooking> ServiceBookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<MechanicOnService> MechanicsOnServices { get; set; }

        public CarServiceContext(DbContextOptions<CarServiceContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany()  
                .HasForeignKey(c => c.ModelCode);
            modelBuilder.Entity<ServiceBooking>()
                .HasOne(sb => sb.Car)
                .WithMany() 
                .HasForeignKey(sb => sb.LicenceNumber);
            modelBuilder.Entity<ServiceBooking>()
                 .HasOne(sb => sb.Customer)
                 .WithMany()
                 .HasForeignKey(sb => sb.CustomerId);
            modelBuilder.Entity<MechanicOnService>()
                .HasOne(mos => mos.Mechanic)
                .WithMany()
                .HasForeignKey(mos => mos.MechanicId);

            modelBuilder.Entity<Model>()
                 .HasOne(m => m.Manufacturer)
                 .WithMany()
                 .HasForeignKey(m => m.ManufacturerCode);
            modelBuilder.Entity<Customer>()
                 .HasIndex(c => c.EmailAddress)
                 .IsUnique();
            modelBuilder.Entity<Car>()
                 .HasOne(c => c.Model)
                 .WithMany(m => m.Cars)
                 .HasForeignKey(c => c.ModelCode)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Model>()
.HasOne(m => m.Manufacturer)
.WithMany(m => m.Models)
.HasForeignKey(m => m.ManufacturerCode)
.OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<MechanicOnService>()
         .HasKey(mos => new { mos.MechanicId, mos.SvcBookingId });  

            modelBuilder.Entity<MechanicOnService>()
                .HasOne(mos => mos.Mechanic)
                .WithMany(m => m.MechanicOnServices)
                .HasForeignKey(mos => mos.MechanicId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MechanicOnService>()
                .HasOne(mos => mos.ServiceBooking)
                .WithMany(sb => sb.MechanicsOnServices)
                .HasForeignKey(mos => mos.SvcBookingId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }

}
