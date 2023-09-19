using Helper;
using Microsoft.Extensions.DependencyInjection;
using NewsAPI;
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

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageDal>();

            services.AddScoped<ISkıllsService, SkıllsManager>();
            services.AddScoped<ISkıllsDal, EfSkıllsDal>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogDal>();

            services.AddScoped<IBlogDetailsService, BlogDetailsManager>();
            services.AddScoped<IBlogDetailsDal, EfBlogDetails>();


            services.AddSingleton<FileUpload>();

            services.AddSingleton<NewsApiClient>(provider => new NewsApiClient("8f6a5cbce9c24e7b991efbb5c20285db"));






        }
    }
}
