using Microsoft.EntityFrameworkCore;
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


            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAboutDal, EfAboutDal>();

            builder.Services.AddScoped<IServiceService, ServiceManager>();
            builder.Services.AddScoped<IServiceDal, EfServiceDal>();

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}