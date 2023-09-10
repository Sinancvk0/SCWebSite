using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SC.Models;

namespace SC.DataLayer
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int>

    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
        public DbSet<Blog> Blogs { get; set; }


    }
   
   



}
