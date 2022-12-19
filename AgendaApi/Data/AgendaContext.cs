using AgendaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Data
{
    public class AgendaContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        
        public DbSet<ContactsBook> ContactsBooks { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
