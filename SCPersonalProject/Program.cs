using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SC.Bussines.Container;
using SC.DataLayer;
using SC.Models;
using SCPersonalProject.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));


            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Login/Index";

            });

         

           


            // SignalR servislerini burada yapýlandýrýn
            builder.Services.AddSignalR();

            ExtensionsDb.ContainerDependencies(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseWebSockets();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}"
            );

            // SignalR Hub yolunu ve baðlantýyý yapýlandýrýn
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<VisitorHub>("/visitorhub"); // SignalR Hub yolunu belirtin
                endpoints.MapControllers(); // Controller endpointleri
            });

            app.Run();
        }
    }
}
