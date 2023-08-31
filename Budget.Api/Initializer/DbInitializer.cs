using Budget.Api.Common;
using Budget.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Budget.Api.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task Initialize()
        {
            if (await _roleManager.FindByNameAsync(BudgetConstants.Admin) == null)
                await _roleManager.CreateAsync(new IdentityRole(BudgetConstants.Admin));

            if (await _roleManager.FindByNameAsync(BudgetConstants.User) == null)
                await _roleManager.CreateAsync(new IdentityRole(BudgetConstants.User));

            var admin = new User
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111111111",
                FirstName = "Admin1",
                LastName = "Admin1",
            };

            if (await _userManager.FindByEmailAsync(admin.Email) == null)
            {
                await _userManager.CreateAsync(admin, "Admin123#");
                await _userManager.AddToRoleAsync(admin, BudgetConstants.Admin);
                await _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.GivenName, admin.FirstName),
                    new Claim(ClaimTypes.Role, BudgetConstants.Admin)
                });
            }

            var user = new User
            {
                UserName = "user1@gmail.com",
                Email = "user1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111111111111",
                FirstName = "User1",
                LastName = "User1",
            };

            if (await _userManager.FindByEmailAsync(user.Email) == null)
            {
                await _userManager.CreateAsync(user, "User123#");
                await _userManager.AddToRoleAsync(user, BudgetConstants.User);
                await _userManager.AddClaimsAsync(user, new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Role, BudgetConstants.User)
               });
            }
        }
    }
}
