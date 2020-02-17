﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgWebTest.DAL;
using IgWebTest.EFContext;
using IgWebTest.Models;
using IgWebTest.Utility.PasswordHashers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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

            services.AddTransient<IUserStore<IgniteUser>, DataStores.UserStore>();
            services.AddTransient<IRoleStore<IgniteRole>, DataStores.RoleStore>();

            services.Configure<PasswordHasherOptions>(options =>
                {
                    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
                });
            services.AddScoped<IPasswordHasher<IgniteUser>, MyPasswordHasher<IgniteUser>>();

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
