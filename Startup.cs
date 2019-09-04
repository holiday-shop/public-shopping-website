using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using dotnetcore_holiday_info.Repository;

namespace dotnetcore_holiday_info
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
            var repoConfig = Configuration.GetSection("Repository");
            var server = repoConfig["Server"];
            var database = repoConfig["Database"];
            var usenameEnvVar = repoConfig["UsernameEnvVar"];
            var passwordEnvVar = repoConfig["PasswordEnvVar"];

            var username = Environment.GetEnvironmentVariable(usenameEnvVar);
            var password = Environment.GetEnvironmentVariable(passwordEnvVar);

            var connectionString = $"Server={server};Database={database};User Id={username};Password={password}";

            services.AddMvc();
            services.AddTransient<IHolidayGeoInformationRepository, MockHolidayGeoInformationRepository>(context =>
            {
                //var holidayGeoInformationRepository = new HolidayGeoInformationRepository(connectionString);
                var holidayGeoInformationRepository = new MockHolidayGeoInformationRepository(connectionString);
                return holidayGeoInformationRepository;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
