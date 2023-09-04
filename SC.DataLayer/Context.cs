using Microsoft.EntityFrameworkCore;
using SC.Models;

namespace SC.DataLayer
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skılls> Skılls { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Experinece> Experineces { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
   
   



}
