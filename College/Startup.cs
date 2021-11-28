using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using College.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace College
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
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                var userId = Configuration["USER_ID"] ?? "sa";
                var password = Configuration["USERPASSWORD"] ?? "mohamed0104859520";
                var port = Configuration["PORT"] ?? "9100";
                Console.WriteLine(userId);
                System.Console.WriteLine(password);
                System.Console.WriteLine(port);
                Console.WriteLine($"Server=college_database,1433;Initial catalog=CollegeDatabase;User ID=sa;password=mohamed0104859520");
                option.UseSqlServer($"Server=college_database,1433;Initial catalog=CollegeDatabase;User ID={userId};password={password}");
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "College", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var service = app.ApplicationServices.GetService<ApplicationDbContext>())
            {
                service.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "College v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
