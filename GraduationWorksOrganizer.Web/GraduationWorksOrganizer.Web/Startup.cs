using GraduationWorksOrganizer.Additional.Services;
using GraduationWorksOrganizer.Additional.SMTP;
using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Additional;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Services.Services;
using GraduationWorksOrganizer.Web.SharedViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
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
            services.AddDirectoryBrowser();
            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            });

            ConfigureAuthorization(services);

            services.AddDbContext<GraduationWorksOrganizerDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationIdentityBase, IdentityRole>()
                .AddEntityFrameworkStores<GraduationWorksOrganizerDataContext>();

            services.AddScoped<IEmailSender, ComformationEmailSender>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IQueryProvider<>), typeof(CombinedQueryBaseService<>));
            services.AddScoped(typeof(IMimeTypeConverter), typeof(MimeTypeConverter));
            services.AddScoped(typeof(ThesisViewModelService<>));
            services.AddScoped(typeof(CombinedQueryBaseService<>));
            services.AddScoped(typeof(TeacherViewModelService<>));
            services.AddScoped(typeof(UserEntryFilesViewModelService<>));

            services.AddScoped<ThesesDatabaseService>();
            services.AddScoped<TeachersDatabaseService>();
            services.AddScoped<ApplicationUserDatabaseService>();
            services.AddScoped<ThesisService>();
            services.AddScoped<StudentDatabaseService>();
            services.AddScoped<UserEntryFilesDatabaseService>();
            services.AddScoped<ThesisApprovementService>();
            services.AddScoped<MapperService>();
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
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.WebRootPath, "images")),
                RequestPath = "/images"
            });

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
                op.AddPolicy(Constants.PolicyNames.AddTheses, p => p.RequireRole(Constants.RoleNames.TeacherRole));
            });
        }
    }
}
