using Microsoft.Extensions.DependencyInjection;
using SC.Bussines.Content;
using SC.Bussines.Services;
using SC.DataLayer.Abstract;
using SC.DataLayer.EntityFramework;

namespace SC.Bussines.Container
{
    public class ExtensionsDb
    {
     

        public static void ContainerDependencies(IServiceCollection services)
        {

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, EfServiceDal>();

            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IWorkDal, EfWorkDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();


        }
    }
}
