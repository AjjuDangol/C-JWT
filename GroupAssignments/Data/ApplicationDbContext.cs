using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupAssignments.Models;
using System.Threading.Tasks;

namespace GroupAssignments.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Seed data method
        public async Task SeedDataAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string managerRole = "Manager";
            string userRole = "User";

            // Create roles if they do not exist
            if (!await roleManager.RoleExistsAsync(managerRole))
            {
                await roleManager.CreateAsync(new IdentityRole(managerRole));
            }

            if (!await roleManager.RoleExistsAsync(userRole))
            {
                await roleManager.CreateAsync(new IdentityRole(userRole));
            }

            // Create users if they do not exist
            var managerUser = await userManager.FindByNameAsync("Manager");
            if (managerUser == null)
            {
                managerUser = new ApplicationUser { UserName = "Manager" };
                await userManager.CreateAsync(managerUser, "ManagerPass123!");
                await userManager.AddToRoleAsync(managerUser, managerRole);
            }

            var normalUser = await userManager.FindByNameAsync("User");
            if (normalUser == null)
            {
                normalUser = new ApplicationUser { UserName = "User" };
                await userManager.CreateAsync(normalUser, "UserPass123!");
                await userManager.AddToRoleAsync(normalUser, userRole);
            }
        }
    }
}
