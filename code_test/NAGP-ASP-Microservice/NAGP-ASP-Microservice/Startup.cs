using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NAGP_ASP_Microservice.DBContexts;
using NAGP_ASP_Microservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAGP_ASP_Microservice
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
            var config = Configuration.GetSection("ConnectionStrings");

            //var host = config.GetValue<string>("HOST") ?? "localhost";
            //var port = config.GetValue<string>("PORT") ?? "1433";
            //var password = config.GetValue<string>("SQL_PASSWORD");

            var host = Environment.GetEnvironmentVariable("HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("PORT") ?? "1433";
            var password = Environment.GetEnvironmentVariable("SQL_PASSWORD") ??config.GetValue<string>("SQL_PASSWORD");
            //password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            var userid = config.GetValue<string>("SQL_USER");
            var usersDataBase = config.GetValue<string>("SQL_DATABASE");
            //var rootUserid = "root";
            //var rootPassword = "Root0++";
           string connString = $"server=tcp:{host},{port}; User Id={userid};Password={password};Initial Catalog={usersDataBase}";

            services.AddDbContext<ProductContext>(x => x.UseSqlServer(connString));
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
