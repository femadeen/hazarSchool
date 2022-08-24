using HazarSchool.HazarSchoolContext;
using HazarSchool.Implementations.Repositories;
using HazarSchool.Implementations.Services;
using HazarSchool.Interfaces.Repositories;
using HazarSchool.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazarSchool
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
            services.AddControllersWithViews();
            services.AddControllersWithViews();
            services.AddDbContext<HazarContext>(options => options.UseMySQL(Configuration.GetConnectionString("SchoolApp")));
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            /* services.AddSession();*/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(config =>
                 {
                     config.LoginPath = "/student/login";
                     config.Cookie.Name = "mySchoolApp";
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            /*app.UseSession();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
