using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgWebTest.DAL;
using IgWebTest.EFContext;
using IgWebTest.Email;
using IgWebTest.Models;
using IgWebTest.UnitOfWork;
using IgWebTest.Utility.PasswordHashers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IgWebTest
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentity<IgniteUser, IgniteRole>()
                .AddDefaultTokenProviders();

            //Configuration.GetSection()
            services.AddDbContext<IgniteTestDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IgniteTestDatabase")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            });

            services.AddTransient<IUserStore<IgniteUser>, DataStores.UserStore>();
            services.AddTransient<IRoleStore<IgniteRole>, DataStores.RoleStore>();

            services.Configure<PasswordHasherOptions>(options =>
                {
                    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
                });
            services.AddScoped<IPasswordHasher<IgniteUser>, MyPasswordHasher<IgniteUser>>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);
            //services.AddControllersWithViews();

            services.AddDataProtection();

            services.Configure<IgWebTest.DAL.ConnectionOptions.ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
