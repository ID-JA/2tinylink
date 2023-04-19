using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContextInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AppDbContextInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
        }
        public async Task SeedAsync()
        {
            // Default roles
            var adminRole = new IdentityRole<Guid>(Roles.Admin.ToString());
            var superuserRole = new IdentityRole<Guid>(Roles.Superuser.ToString());

            // Default Password
            var password = "Pa$$w0rd";

            if (await _roleManager.Roles.AllAsync(r => r.Name != adminRole.Name))
            {
                await _roleManager.CreateAsync(adminRole);
            }
            if (await _roleManager.Roles.AllAsync(r => r.Name != superuserRole.Name))
            {
                await _roleManager.CreateAsync(superuserRole);
            }

            // Default users
            var admin = new AppUser
            {
                FirstName = "Admin",
                LastName = "User",
                UserName = "admin.user",
                Email = "admin.user@2tinylink.com",
                EmailConfirmed = true
            };

            var user = new AppUser
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = "john.doe",
                Email = "john.doe@2tinylink.com",
                EmailConfirmed = true
            };

            if (await _userManager.Users.AllAsync(u => u.UserName != admin.UserName))
            {
                await _userManager.CreateAsync(admin, password);

                if (!string.IsNullOrWhiteSpace(adminRole.Name))
                {
                    await _userManager.AddToRolesAsync(admin, new[] { adminRole.Name });
                }
            }
            if (await _userManager.Users.AllAsync(u => u.UserName != user.UserName))
            {
                await _userManager.CreateAsync(user, password);

                if (!string.IsNullOrWhiteSpace(superuserRole.Name))
                {
                    await _userManager.AddToRolesAsync(user, new[] { superuserRole.Name });
                }
            }
        }


    }
}