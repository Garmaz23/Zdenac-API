using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Zdenac_API.Models;

namespace Zdenac_API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Role relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Location relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Location)
                .WithMany()
                .HasForeignKey(u => u.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Gender relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Gender)
                .WithMany()
                .HasForeignKey(u => u.GenderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Children - Gender relationship
            modelBuilder.Entity<Child>()
                .HasOne(c => c.Gender)
                .WithMany()
                .HasForeignKey(c => c.GenderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Children - Institution relationship
            modelBuilder.Entity<Child>()
                .HasOne(c => c.Institution)
                .WithMany()
                .HasForeignKey(c => c.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict); // Restricting to prevent multiple cascade paths

            // Children - Location relationship
            modelBuilder.Entity<Child>()
                .HasOne(c => c.BirthLocation)
                .WithMany()
                .HasForeignKey(c => c.BirthLocationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Institution - User relationship
            modelBuilder.Entity<Institution>()
                .HasOne(i => i.Guardian)
                .WithMany()
                .HasForeignKey(i => i.GuardianId)
                .OnDelete(DeleteBehavior.Cascade);

            // Location - City relationship
            modelBuilder.Entity<Location>()
                .HasOne(l => l.City)
                .WithMany()
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            // Location - Country relationship
            modelBuilder.Entity<Location>()
                .HasOne(l => l.Country)
                .WithMany()
                .HasForeignKey(l => l.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Donation - User relationship
            modelBuilder.Entity<Donation>()
                .HasOne(d => d.Sponsor) // Assuming User property exists in Donation class
                .WithMany()
                .HasForeignKey(d => d.SponsorId)
                .OnDelete(DeleteBehavior.Restrict); // Restricting to prevent multiple cascade paths
            

            modelBuilder.Entity<Multimedia>()
                .HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);
  
            modelBuilder.Entity<Parent>()
                    .HasOne(p => p.Child)
                    .WithMany() // or .WithMany(c => c.Parents) if you have a collection on the Child side
                    .HasForeignKey(p => p.ChildId)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Parent>()
                .HasOne(p => p.User)
                .WithMany() // or .WithMany(u => u.Parents) if you have a collection on the User side
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }


        public DbSet<Child> Children { get; set; }
       

    }
}
