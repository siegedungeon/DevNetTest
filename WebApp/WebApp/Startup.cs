using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebApp.Helpers;
using WebApp.Models.User;
using WebApp.Services.Blog;
using WebApp.Services.Login;

namespace WebApp
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddIdentity<AppUser, IdentityRole>()
               .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(o =>
             {
                 o.LoginPath = new PathString("/Account/Login");
                 o.Cookie.Name = "Sirv3";
                 o.LoginPath = "/access";
             });

            services.AddControllersWithViews()
                 .AddSessionStateTempDataProvider();
            services.AddRazorPages()
                .AddSessionStateTempDataProvider();
            services.AddMvc()
                .AddSessionStateTempDataProvider()
                .AddCookieTempDataProvider();
            services.AddOptions();

            services.Configure<UrlApi>(Configuration.GetSection("UrlBack"));

            //Article
            services.AddTransient<IArticle, ArticleModel>();
            //Login
            services.AddTransient<ILogin, LoginService>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
