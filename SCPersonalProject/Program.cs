using Microsoft.EntityFrameworkCore;
using SC.Bussines.Container;
using SC.Bussines.Content;
using SC.Bussines.Services;
using SC.DataLayer;
using SC.DataLayer.Abstract;
using SC.DataLayer.EntityFramework;
using SC.Models;

namespace SCPersonalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
      
            var builder = WebApplication.CreateBuilder(args);


       
            // Add services to the container.
            builder.Services.AddControllersWithViews();
         
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();    

            ExtensionsDb.ContainerDependencies(builder.Services);

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
             name: "areas",
             pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
         );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}"
            );

            app.Run();

        }
    }
}