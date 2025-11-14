using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace BeeBuzz.Data.Seeding
{
    public class Seeder
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public Seeder(ApplicationDbContext context, IWebHostEnvironment environment, RoleManager<IdentityRole<int>> roleManager, UserManager<ApplicationUser> userManager) 
        {
            _context = context;
            _environment = environment;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Organization")); //Organization and a Default and Admin roles
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            ApplicationUser admin = await SeedAdminUser();

            var seedData = LoadSeedData();

            if (!_context.Organizations.Any())
            {
                foreach (Organization organization in _context.Organizations)
                {
                    organization.User = admin;
                }
                _context.Organizations.AddRange(seedData.Organizations);
                _context.SaveChanges();
            }      
            
            if (!_context.Beehives.Any())
            {
                foreach (Beehive beehive in seedData.Beehive)
                {
                    beehive.User = admin;
                }
                _context.Beehives.AddRange(seedData.Beehive);
                _context.SaveChanges();
            }      
            
            if (!_context.Beehives.Any())
            {
                _context.Beehives.AddRange(seedData.Beehive);
                _context.SaveChanges();
            }


        }

        public async Task<ApplicationUser> SeedAdminUser()
        {
            const string adminRoleName = "Admin";
            const string adminUsername = "admin";
            const string adminEmail = "web@web.com";
            const string adminPassword = "Password!W3b";

            if (!await _roleManager.RoleExistsAsync(adminRoleName))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(adminRoleName));
            }

            var existingAdmin = await _userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin != null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminUsername,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, adminRoleName);

                    return adminUser;
                } else
                {
                    throw new Exception("Failed to create admin");
                }
            }
            return existingAdmin;
        }

        private SeedData LoadSeedData()
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "Data/data.json");

            if (!File.Exists(filePath)) throw new FileNotFoundException("Seed data file not found.");
                var json = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var data = JsonSerializer.Deserialize<SeedData>(json, options);
                return data ?? new SeedData();
            
        }
    }
}
