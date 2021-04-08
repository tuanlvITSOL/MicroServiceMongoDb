using CatalogAPI.Data;
using CatalogAPI.Data.Interfaces;
using CatalogAPI.Entities;
using CatalogAPI.Repositories.BaseResponsitory.ImplementBase;
using CatalogAPI.Repositories.Implements;
using CatalogAPI.Repositories.interfaceBase;
using CatalogAPI.Repositories.Interfaces;
using CatalogAPI.Services.Implements;
using CatalogAPI.Services.Interfaces;
using CatalogAPI.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CatalogAPI
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
            
            services.Configure<CatalogDatabaseSettings>(Configuration.GetSection(nameof(CatalogDatabaseSettings)));
            services.AddSingleton<ICatalogDatabaseSettings>(sp => sp.GetRequiredService<IOptions<CatalogDatabaseSettings>>().Value);

            services.AddTransient<IMongoContext, MongoContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategotyReponsitory, CategoryReponsitory>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API V1");
            });
        }
    }
}
