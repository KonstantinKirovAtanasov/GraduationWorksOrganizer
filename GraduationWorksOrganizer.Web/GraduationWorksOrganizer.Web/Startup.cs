using GraduationWorksOrganizer.Additional.SMTP;
using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Additional;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Services;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.Base;
using GraduationWorksOrganizer.Services.Commissions;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using GraduationWorksOrganizer.Web.SharedViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web
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
            services.AddRazorPages();
            services.AddAuthentication();
            ConfigureAuthorization(services);

            services.AddDbContext<GraduationWorksOrganizerDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationIdentityBase, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<GraduationWorksOrganizerDataContext>();

            services.AddScoped<IEmailSender, ComformationEmailSender>();
            services.AddScoped<IAsyncRepository, BaseRepository>();

            services.AddScoped<TeacherService<TeacherViewModel>>();
            services.AddScoped<ThesisService<ThesesViewModel>>();
            services.AddScoped<ThesisService<PreviewThesisViewModel>>();

            services.AddScoped<CommissionsService>();
            services.AddScoped<ThesesDatabaseService>();
            services.AddScoped<TeachersDatabaseService>();
            services.AddScoped<ApplicationUserDatabaseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();
            SetupRolesAndClaims(app.ApplicationServices.CreateScope().ServiceProvider).Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Метод който сетъп-ва роли и клеймове в приложението
        /// </summary>
        /// <param name="services"></param>
        private async Task SetupRolesAndClaims(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Constants.RoleNames.AdminRole))
                await roleManager.CreateAsync(new IdentityRole(Constants.RoleNames.AdminRole));
            if (!await roleManager.RoleExistsAsync(Constants.RoleNames.PromotedTeacherRole))
                await roleManager.CreateAsync(new IdentityRole(Constants.RoleNames.PromotedTeacherRole));
            if (!await roleManager.RoleExistsAsync(Constants.RoleNames.TeacherRole))
                await roleManager.CreateAsync(new IdentityRole(Constants.RoleNames.TeacherRole));
            if (!await roleManager.RoleExistsAsync(Constants.RoleNames.StudentRole))
                await roleManager.CreateAsync(new IdentityRole(Constants.RoleNames.StudentRole));
        }

        /// <summary>
        /// Метод който сетъп-ва policies в приложението
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(op =>
            {
                op.AddPolicy(Constants.PolicyNames.ViewTheses, p => p.RequireRole(Constants.RoleNames.StudentRole, Constants.RoleNames.TeacherRole, Constants.RoleNames.PromotedTeacherRole));
                op.AddPolicy(Constants.PolicyNames.ApproveTheses, p => p.RequireRole(Constants.RoleNames.TeacherRole, Constants.RoleNames.PromotedTeacherRole));
                op.AddPolicy(Constants.PolicyNames.AddTheses, p => p.RequireRole(Constants.RoleNames.StudentRole, Constants.RoleNames.TeacherRole));
            });
        }
    }
}
