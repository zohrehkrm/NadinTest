
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NadinTest.Core.Models.Users;
using System;
using System.Linq;

namespace NadinTest.Configuration.DataInitializer
{
    public class UserDataInitializer : IDataInitializer
    {
        private readonly UserManager<User> userManager;

        public UserDataInitializer(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public int order { get; set; } = 2;
        public void InitializeData()
        {
            if (!userManager.Users.AsNoTracking().Any(p => p.UserName == "Admin"))
            {
                var user = new User
                {
                    PassWord ="admin1234"
                        };
                var result = userManager.CreateAsync(user, "admin1234").GetAwaiter().GetResult();
            }
            if (!userManager.Users.AsNoTracking().Any(p => p.UserName == "zohreh"))
            {
                var user = new User
                {
                    PassWord = "admin1234"
                };
                var result = userManager.CreateAsync(user, "admin1234").GetAwaiter().GetResult();
            }
           
        }
    }
}