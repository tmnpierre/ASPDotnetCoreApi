using Exercice04Contact.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice04Contact.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact>? Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}