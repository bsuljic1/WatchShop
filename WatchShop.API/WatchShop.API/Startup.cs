using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WatchShop.Model;
using AutoMapper;
using WatchShop.BLL.Implementation;
using WatchShop.BLL.Interfaces;
using WatchShop.DAL.Implementation;
using WatchShop.DAL.Interfaces;

namespace WatchShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WatchShop.API", Version = "v1" });
            });

            services.AddDbContext<WatchShopDatabaseContext>(options => options.UseSqlServer("name=ConnectionStrings:LibraryDb"));

            services.AddCors(options => options.AddPolicy(
                "myPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
               )
            );

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IConditionService, ConditionService>();
            services.AddScoped<IConditionRepository, ConditionRepository>();
            services.AddScoped<IStyleService, StyleService>();
            services.AddScoped<IStyleRepository, StyleRepository>();
            services.AddScoped<IWatchService, WatchService>();
            services.AddScoped<IWatchRepository, WatchRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWishListService, WishListService>();
            services.AddScoped<IWishListRepository, WishListRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("myPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WatchShop.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
