using NadinTest.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NadinTest.Configuration.DataInitializer
{
    public class RoleDataInitializer : IDataInitializer
    {
        private readonly RoleManager<Role> roleManager;

        public RoleDataInitializer(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public int order { get; set; } = 1;

        public void InitializeData()
        {
            if (!roleManager.Roles.AsNoTracking().Any(p => p.Name == "Admin"))
            {
                var Role = new Role() { Name = "Admin", Description = "Admin" };
                var result = roleManager.CreateAsync(Role).GetAwaiter().GetResult();
            }
            if (!roleManager.Roles.AsNoTracking().Any(p => p.Name == "User"))
            {
                var Role = new Role() { Name = "User", Description = "User" };
                var result = roleManager.CreateAsync(Role).GetAwaiter().GetResult();
            }
        }
    }
}