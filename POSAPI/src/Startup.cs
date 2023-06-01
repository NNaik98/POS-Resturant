using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Newtonsoft.Json;

namespace POSAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = Configuration.GetSection("DbConnections")["POSAPI"];
            System.Console.WriteLine("Using DB " + dbConnectionString.Split('=')[3].Split(';')[0]);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", cors =>
                {
                    cors.WithOrigins("http://localhost:5031", "http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddDbContext<Model>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseMySql(dbConnectionString, new MySqlServerVersion(new System.Version(8, 0, 31)));
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "POSAPI", Version = "v1" });
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POSAPI"));
            }

            app.UseCors("AllowAll");
           /* app.UseHttpsRedirection();*/

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
