using DotNetContactsApp.Models;
using Microsoft.EntityFrameworkCore;
using DotNetContactsApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// Context used by this app to connect to the local SQLite database.
// It implements IdentityDbContext for user authorization.
namespace DotNetContactsApp.Data
{
    public class ApplicationLocalDbContext : IdentityDbContext<ContactsAppUser>
    {
        public ApplicationLocalDbContext(DbContextOptions<ApplicationLocalDbContext> options)
            : base(options)
        {
        }

        // Your existing application-specific entities
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
