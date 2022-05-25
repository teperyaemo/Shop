using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Shop
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(Microsoft.Extensions.Hosting.IHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedAccount = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDBContent>();
            services.AddControllersWithViews();
            services.AddTransient<IAllDetails, DetailRepository>();
            services.AddTransient<IDetailsCategory, CategoryRepository>();
            services.AddTransient<ICharecs, CharesRepository>();
            services.AddTransient<IDetailCharecs, DetailCharacteristicsRepository>();
            services.AddTransient<IDetailsImages, ImageRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IOrderDetail, OrderDetailRepository>();
            services.AddTransient<EmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Details/{action}/{category?}", defaults: new { Controller = "Details", action = "Catalog" });
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                
            }

            app.UseAuthentication();
            app.UseAuthorization();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
