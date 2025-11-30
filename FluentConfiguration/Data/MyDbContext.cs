using FluentConfiguration.Model;
using Microsoft.EntityFrameworkCore;

namespace FluentConfiguration.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {


        }

        public DbSet<Units> Units { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Units>();
            modelBuilder.Entity<Units>().ToTable("Units");
            modelBuilder.Entity<Units>().HasKey(p => p.Id);
            modelBuilder.Entity<Units>().Property(p => p.UnitType).IsRequired();
            modelBuilder.Entity<Units>().Property(p => p.UnitSize).IsRequired();
            modelBuilder.Entity<Units>().Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();
            modelBuilder.Entity<Units>().HasDiscriminator(x => x.UnitType)
                .HasValue<House>(nameof(House))
                 .HasValue<Apartment>(nameof(Apartment))
                  .HasValue<Office>(nameof(Office));


            modelBuilder.Entity<Apartment>().OwnsOne(x => x.ApartmentAmenities, am =>
            {
                am.Property(p => p.FloorNumber).IsRequired();
                am.Property(p =>p.HasBalcony).IsRequired();
            });

            modelBuilder.Entity<House>().OwnsOne(x => x.HouseAmenities, am =>
            {
                am.Property(p => p.NumberOfBedrooms).IsRequired();
                am.Property(p => p.HasGarge).IsRequired();
            });

            modelBuilder.Entity<Office>().OwnsOne(x => x.OfficeAmenities, am =>
            {
                am.Property(p => p.NumberOfWorkspaces).IsRequired();
                am.Property(p => p.HasConferenceRoom).IsRequired();
            });


        }

    }
}
