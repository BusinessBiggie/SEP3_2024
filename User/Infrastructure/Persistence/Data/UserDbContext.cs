using Microsoft.EntityFrameworkCore;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Infrastructure.Persistence.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurer User
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(); // Email skal være unik

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique(); // Username skal være unik

            // Konfigurer 1-til-mange relation mellem User og Location
            modelBuilder.Entity<User>()
                .HasMany(u => u.Locations) // En bruger kan have mange lokationer
                .WithOne(l => l.User) // Hver lokation har én bruger
                .HasForeignKey(l => l.UserID) // Fremmednøgle i Location
                .OnDelete(DeleteBehavior.Cascade); // Hvis brugeren slettes, slettes også lokationerne

            base.OnModelCreating(modelBuilder);
        }
    }
}