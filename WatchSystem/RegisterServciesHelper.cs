using BL.Contracts.GeneralService.CMS;
using BL.Contracts.GeneralService.UserManagement;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.GeneralService.CMS;
using BL.GeneralService.UserManagement;
using BL.Mapper;
using BL.Mapper.Base;
using BL.Services;
using DAL.ApplicationContext;
using DAL.Contracts.Repositories.Custom;
using DAL.Contracts.Repositories.Generic;
using DAL.Contracts.UnitOfWork;
using DAL.Repositories.Custom;
using DAL.Repositories.Generic;
using DAL.UnitOfWork;
using Domains.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

using WatchSystem;
using WatchSystem.Services.Contracts;

namespace WatchSystem
{
    public class RegisterServicesHelper
    {
        public static void RegisteredServices(WebApplicationBuilder builder)
        {
            // Configure Entity Framework 
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configure password, lockout, and other Identity options if needed
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Configure Identity options and authentication cookie settings
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "Cookie";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;

            });

            // Configure Serilog for logging
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.MSSqlServer(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            tableName: "Log",
            autoCreateSqlTable: true)
           .CreateLogger();

            // Register Serilog logger
            builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

            // Register Auto Mapper
            builder.Services.AddAutoMapper(typeof(Program)); // Assuming 'Program' contains AutoMapper profiles
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Register repositories
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(ITableRepository<>), typeof(TableRepository<>));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IBaseMapper), typeof(BaseMapper));

            // CMS
            builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            //builder.Services.AddScoped<IUserTokenService, UserTokenService>();
            builder.Services.AddScoped<IRoleManagementService, RoleManagementService>();
            builder.Services.AddScoped<IFileUploadService, FileUploadService>();
            builder.Services.AddScoped<IFileHandlerService, FileHandlerService>();
            builder.Services.AddScoped<IImageProcessingService, ImageProcessingService>();
            builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();

            // Register localization and set the resources folder path
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Project Services
            builder.Services.AddScoped<ITypeService, TypeService>();
            builder.Services.AddScoped<ISliderService, SliderService>();
            builder.Services.AddScoped<IDescriptionService, DescriptionService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<ISalesInvoiceService, SalesInvoiceService>();
            builder.Services.AddScoped<ISalesInvoiceItemService, SalesInvoiceItemService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<ISettingsService, SettingsService>();

            builder.Services.AddScoped<IItemRepository, ItemRepository>();



        }
    }
}
