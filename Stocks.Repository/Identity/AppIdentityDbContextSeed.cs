using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Stocks.Core.Entites.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Repository.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var User = new AppUser()

                {
                    DisplayName = "shorbagy",
                    Email = "shorbagy.1996@gmail.com",
                    UserName = "shorbagy",
                    PhoneNumber = "01110812579",
                };
            await userManager.CreateAsync(User , "@dmin");
            }
            


        }

    }
}
