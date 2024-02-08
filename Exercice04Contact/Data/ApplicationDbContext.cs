using Exercice04Contact.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice04Contact.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<User>? Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.Gender).HasConversion<string>();
                entity.Property(e => e.Avatar).IsRequired(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(30);
            });
        }
    }
}
