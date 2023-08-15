
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Zdenac_API.Models;


namespace Zdenac_API.Data
{
    public class DataContext:IdentityDbContext<ApiUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
          
            modelBuilder.Entity<Log>()
        .HasOne(l => l.User)
        .WithMany() // or .WithMany(u => u.Logs) if you have a collection on the User side
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Child)
                .WithMany() // Assuming Child does not have a navigation property for Sessions
                .HasForeignKey(s => s.ChildId)
                .OnDelete(DeleteBehavior.NoAction); // Or .OnDelete(DeleteBehavior.NoAction) based on your requirement

            modelBuilder.Entity<Session>()
                .HasOne(s => s.User)
                .WithMany() // Assuming User does not have a navigation property for Sessions
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Or .OnDelete(DeleteBehavior.NoAction) based on your requirement

            modelBuilder.Entity<PasswordReset>()
               .HasOne(pr => pr.User)
               .WithMany() // Assuming User does not have a navigation property for PasswordResets
               .HasForeignKey(pr => pr.UserId)
               .OnDelete(DeleteBehavior.NoAction); // Or .OnDelete(DeleteBehavior.NoAction) based on your requirement

            // Configure Notification relationships
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany() // Assuming User does not have a navigation property for Notifications
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Or .OnDelete(DeleteBehavior.NoAction) based on your requirement


        }


        public DbSet<Child> Children { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonationType> DonationTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<Role> Roles { get; set; }
        

    }
}
