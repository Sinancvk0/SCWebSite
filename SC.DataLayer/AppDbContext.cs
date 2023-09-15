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
        public virtual  DbSet<About> Abouts { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Skılls> Skılls { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Experinece> Experineces { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<BlogCategory> GetBlogCategories { get; set; }
        public virtual DbSet<BlogDetaills> BlogDetaills { get; set; }
       


    }
   
   



}
