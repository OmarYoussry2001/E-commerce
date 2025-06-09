using Domains.Entities;
using Domains.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ApplicationContext
{
    public class ContextConfigurations
    {
        private static readonly string seedAdminEmail = "admin@gmail.com";
        private static readonly string seedAdminPassword = "123456";

        public static async Task SeedDataAsync(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Seed user first to get admin user ID
            var adminUserId = await SeedUserAsync(userManager, roleManager);

            // Seed E-commerce data
            await SeedECommerceDataAsync(context, adminUserId);
        }
        private static async Task SeedECommerceDataAsync(ApplicationDbContext context, Guid adminUserId)
        {
            // 1. Seed TbSlider
            if (!context.TbSlider.Any())
            {
                var sliders = new List<TbSlider>
        {
            new TbSlider
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعة رجالية فاخرة",
                TitleEn = "Luxury Men's Watch",
                DisplayOrder = 1,
                DescriptionAr = "اكتشف أناقة لا مثيل لها مع هذه الساعة السويسرية الفاخرة المصنوعة بدقة عالية.",
                DescriptionEn = "Discover unmatched elegance with this premium Swiss-made men's watch.",
                ImagePath = "images/sliders/mens-luxury-watch.webp",
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = DateTime.UtcNow
            },
            new TbSlider
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعة نسائية أنيقة",
                TitleEn = "Elegant Women's Watch",
                DisplayOrder = 2,
                DescriptionAr = "أضيفي لمسة من الرقي لإطلالتك مع هذه الساعة النسائية الراقية.",
                DescriptionEn = "Add a touch of sophistication to your outfit with this elegant women's watch.",
                ImagePath = "images/sliders/womens-elegant-watch.webp",
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = DateTime.UtcNow
            }
        };

                await context.TbSlider.AddRangeAsync(sliders);
                await context.SaveChangesAsync();
            }

            // 2. Seed TbType
            if (!context.TbType.Any())
            {
                var now = DateTime.UtcNow;

                var types = new List<TbType>
        {
            new TbType
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعات رجالية",
                TitleEn = "Men's Watches",
                ImagePath = "images.webp",
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbType
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعات نسائية",
                TitleEn = "Women's Watches",
                ImagePath = "images.webp",
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbType
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعات ذكية",
                TitleEn = "Smart Watches",
                ImagePath = "images.webp",
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            }
        };

                await context.TbType.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }

            // 3. Seed TbItem
            if (!context.TbItem.Any())
            {
                var now = DateTime.UtcNow;

                var menType = await context.TbType.FirstOrDefaultAsync(t => t.TitleEn == "Men's Watches");
                var womenType = await context.TbType.FirstOrDefaultAsync(t => t.TitleEn == "Women's Watches");
                var smartType = await context.TbType.FirstOrDefaultAsync(t => t.TitleEn == "Smart Watches");

                if (menType == null || womenType == null || smartType == null)
                    return;

                var items = new List<TbItem>
        {
            new TbItem
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعة رجالية كلاسيكية",
                TitleEn = "Classic Men's Watch",
                ImagePathBackGround = "images.webp",
                SerialNo = "MW-1001",
                Price = 450.00m,
                DiscountPercent = 15,
                TypeId = menType.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbItem
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعة نسائية ذهبية",
                TitleEn = "Golden Women's Watch",
                ImagePathBackGround = "images.webp",
                SerialNo = "WW-2001",
                Price = 520.00m,
                DiscountPercent = 10,
                TypeId = womenType.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbItem
            {
                Id = Guid.NewGuid(),
                TitleAr = "ساعة ذكية بلوتوث",
                TitleEn = "Bluetooth Smart Watch",
                ImagePathBackGround = "images.webp",
                SerialNo = "SW-3001",
                Price = 320.00m,
                DiscountPercent = null,
                TypeId = smartType.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            }
        };

                await context.TbItem.AddRangeAsync(items);
                await context.SaveChangesAsync();
            }

            // 4. Seed TbDescription
            if (!context.TbDescription.Any())
            {
                var now = DateTime.UtcNow;

                var menItem = await context.TbItem.FirstOrDefaultAsync(i => i.TitleEn == "Classic Men's Watch");
                var womenItem = await context.TbItem.FirstOrDefaultAsync(i => i.TitleEn == "Golden Women's Watch");
                var smartItem = await context.TbItem.FirstOrDefaultAsync(i => i.TitleEn == "Bluetooth Smart Watch");

                if (menItem == null || womenItem == null || smartItem == null)
                    return;

                var descriptions = new List<TbDescription>
        {
            new TbDescription
            {
                Id = Guid.NewGuid(),
                Size = "42mm",
                ColorAr = "فضي",
                ColorEn = "Silver",
                BenefitDescriptionAr = "مقاومة للماء حتى 50 متر",
                BenefitDescriptionEn = "Water resistant up to 50 meters",
                QualityAr = "سوار من الجلد الطبيعي عالي الجودة",
                QualityEn = "High-quality genuine leather strap",
                Quantity = 100,
                ItemId = menItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbDescription
            {
                Id = Guid.NewGuid(),
                Size = "38mm",
                ColorAr = "ذهبي",
                ColorEn = "Gold",
                BenefitDescriptionAr = "تصميم أنيق مع وجه مرصع بالأحجار",
                BenefitDescriptionEn = "Elegant design with a gem-studded dial",
                QualityAr = "معدن مقاوم للخدوش",
                QualityEn = "Scratch-resistant metal",
                Quantity = 80,
                ItemId = womenItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbDescription
            {
                Id = Guid.NewGuid(),
                Size = "44mm",
                ColorAr = "أسود",
                ColorEn = "Black",
                BenefitDescriptionAr = "متصل بالهاتف عبر البلوتوث مع إشعارات ذكية",
                BenefitDescriptionEn = "Bluetooth connectivity with smart notifications",
                QualityAr = "شاشة OLED عالية الوضوح",
                QualityEn = "High-definition OLED display",
                Quantity = 50,
                ItemId = smartItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            }
        };

                await context.TbDescription.AddRangeAsync(descriptions);
                await context.SaveChangesAsync();
            }

            // 5. Seed TbImage
            if (!context.TbImage.Any())
            {
                var now = DateTime.UtcNow;

                var menItem = await context.TbItem.FirstOrDefaultAsync(i => i.TitleEn == "Classic Men's Watch");
                var womenItem = await context.TbItem.FirstOrDefaultAsync(i => i.TitleEn == "Golden Women's Watch");
                var smartItem = await context.TbItem.FirstOrDefaultAsync(i => i.TitleEn == "Bluetooth Smart Watch");

                if (menItem == null || womenItem == null || smartItem == null)
                    return;

                var images = new List<TbImage>
        {
            new TbImage
            {
                Id = Guid.NewGuid(),
                ImagePath = "images/items/mens-watch-1.webp",
                ItemId = menItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbImage
            {
                Id = Guid.NewGuid(),
                ImagePath = "images/items/mens-watch-2.webp",
                ItemId = menItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbImage
            {
                Id = Guid.NewGuid(),
                ImagePath = "images/items/womens-watch-1.webp",
                ItemId = womenItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbImage
            {
                Id = Guid.NewGuid(),
                ImagePath = "images/items/womens-watch-2.webp",
                ItemId = womenItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbImage
            {
                Id = Guid.NewGuid(),
                ImagePath = "images/items/smart-watch-1.webp",
                ItemId = smartItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            },
            new TbImage
            {
                Id = Guid.NewGuid(),
                ImagePath = "images/items/smart-watch-2.webp",
                ItemId = smartItem.Id,
                CurrentState = 1,
                CreatedBy = adminUserId,
                CreatedDateUtc = now
            }
        };

                await context.TbImage.AddRangeAsync(images);
                await context.SaveChangesAsync();
            }

            // 6. Seed TbSettings
            if (!context.TbSettings.Any())
            {
                var now = DateTime.UtcNow;

                var setting = new TbSettings
                {
                    Id = Guid.NewGuid(),
                    CurrentState = 1,
                    CreatedBy = Guid.Empty,
                    CreatedDateUtc = now,
                    UpdatedBy = null,
                    UpdatedDateUtc = null,

                    WebsiteNameAr = "موقع فيلفورا",
                    WebsiteNameEn = "Velvora Website",
                    Logo = "WatchSystem_logo.png",
                    FacebookLink = "https://www.facebook.com/velvora",
                    TwitterLink = "https://twitter.com/velvora",
                    InstagramLink = "https://instagram.com/velvora",
                    YoutubeLink = "https://youtube.com/velvora",
                    Address = "123 شارع النيل، القاهرة، مصر",
                    ContactNumber = "+201127382518",
                    Email = "omarsunbati@gmail.com",
                    Fax = "+2 3648638"

                };

                context.TbSettings.Add(setting);
                context.SaveChanges();
            }
            ;


        }




        private static async Task<Guid> SeedUserAsync(UserManager<ApplicationUser> userManager,
                    RoleManager<IdentityRole> roleManager)
        {
            // Ensure roles exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }



            if (!await roleManager.RoleExistsAsync("Employee"))
            {
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            // Ensure admin user exists
            var adminEmail = seedAdminEmail;
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var id = Guid.NewGuid().ToString();
                adminUser = new ApplicationUser
                {
                    Id = id,
                    UserName = adminEmail,
                    City = "Cairo",
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "Eladmin",
                    EmailConfirmed = true,
                    CreatedDateUtc = DateTime.UtcNow
                };
                var result = await userManager.CreateAsync(adminUser, seedAdminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Convert adminUser.Id from string to Guid
            return Guid.Parse(adminUser.Id);  // Convert to Guid
        }
    }
}
