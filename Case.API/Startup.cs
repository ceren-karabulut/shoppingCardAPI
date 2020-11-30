using Case.Data.Context;
using Case.Repository.Abstract;
using Case.Repository.Concrete;
using Case.Service.Abstract;
using Case.Service.Concrete;
using Case.Service.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Case.API
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
            
            //repositories
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            //service
            services.AddTransient<IUnit, Unit>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IBasketService , BasketService>();

            
            
            //redis
            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "Case";
                options.Configuration = "localhost:6379";
            });

            
            services.AddSession(options =>
            {
                options.Cookie.Name = ".Ceren.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
               

            });
            

            //db
            services.AddDbContext<CaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Case API",
                    Version = "v1"
                });

                //for swagger commands
                var xmlFile = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlFilePath);
            });

            //cookies
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });

            //session
           
           
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger()
             .UseSwaggerUI(c => {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "Case API v1");
             });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
