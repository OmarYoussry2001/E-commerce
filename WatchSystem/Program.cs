using DAL.ApplicationContext;
using Domains.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Resources;
using Resources.Enumerations;
using System.Globalization;
using WatchSystem;

namespace WatchSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            RegisterServicesHelper.RegisteredServices(builder);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // Use resources for multi-language support
            ResourceManager.CurrentLanguage = Language.Arabic;
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("ar-EG")

            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                // Default  For Language
                DefaultRequestCulture = new RequestCulture(ResourceManager.GetCultureName(ResourceManager.CurrentLanguage)),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
              {
        new CookieRequestCultureProvider(), // Check culture from cookies
        new AcceptLanguageHeaderRequestCultureProvider() // Fallback to header if no cookie
           }
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
           name: "Admin",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
                 .WithStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();



            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var dbContext = services.GetRequiredService<ApplicationDbContext>();

                // Apply migrations
                await dbContext.Database.MigrateAsync();

                // Seed data
                await ContextConfigurations.SeedDataAsync(dbContext, userManager, roleManager);


            }


            app.Run();
        }
    }
}
