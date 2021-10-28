namespace AutoHub.Web.Extensions
{
    using AutoHub.Data;
    using AutoHub.Data.Common;
    using AutoHub.Data.Common.Repositories;
    using AutoHub.Data.Models;
    using AutoHub.Data.Repositories;
    using AutoHub.Services.Data;
    using AutoHub.Services.Data.Implementations;
    using AutoHub.Services.Messaging;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomApplictionServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IEmailSender>(x => new SendGridEmailSender(configuration["SendGrid:ApiKey"]));

            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IMakeService, MakesService>();
            services.AddTransient<IColorService, ColorsService>();
            services.AddTransient<ICoupesService, CoupesService>();
            services.AddTransient<IModelsService, ModelsService>();
            services.AddTransient<IConditionsService, ConditionsService>();
            services.AddTransient<IGearBoxesService, GearBoxesService>();
            services.AddTransient<IRegionsServices, RegionsService>();
            services.AddTransient<IFuelsServices, FuelsServices>();
            services.AddTransient<IAdditionsService, AdditionsService>();
            services.AddTransient<ICarsService, CarsService>();
            services.AddTransient<ITonwsService, TownsService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<IVotesService, VotesService>();
            return services;
        }

        public static IServiceCollection AddRepositoryes(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            return services;
        }

        public static IServiceCollection AddExternalLoginProviders(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
                .AddFacebook(opt =>
                    {
                        opt.AppId = configuration["Facebook:AppId"];
                        opt.AppSecret = configuration["Facebook:AppSecret"];
                    })
               .AddGoogle(opt =>
                    {
                        opt.ClientId = configuration["Google:ClientId"];
                        opt.ClientSecret = configuration["Google:ClientSecret"];
                    });

            return services;
        }


        public static IServiceCollection AddAntyForgery(this IServiceCollection services)
        {
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            return services;
        }

        public static IServiceCollection AppplyControllers(this IServiceCollection services)
        {
            services.AddControllersWithViews(
                options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                }).AddRazorRuntimeCompilation();

            return services;
        }

        public static IServiceCollection ConfigureCookies(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });
            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
              options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
