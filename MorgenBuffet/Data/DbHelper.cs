using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MorgenBuffet.Models;
using System.Threading;

namespace MorgenBuffet.Data
{
    public class DbHelper
    {
        public static List<ApplicationUser> logIn;
        public static void SeedData(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            SeedAdmin(userManager);
            Thread.Sleep(7000);
            SeedKitchen(userManager);
            Thread.Sleep(7000);
            SeedRestaurant(userManager);
            Thread.Sleep(7000);
            SeedReception(userManager);
        }
        public static void SeedAdmin(UserManager<ApplicationUser> userManager)
        {
            const string adminEmail = "Admin@localhost";
            const string adminPassword = "Secret7/";

            var user = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                Name = "Admin"
            };
            IdentityResult result = userManager.CreateAsync(user, adminPassword).Result;
            if (result.Succeeded)
            {
                var adminClaim = new Claim("Admin", "Yes");
                userManager.AddClaimAsync(user, adminClaim);
            }
        }

            public static void SeedKitchen(UserManager<ApplicationUser> userManager)
            {
                const string KitchenEmail = "Kitchen@localhost";
                const string KitchenPassword = "Secret8/";

                var userKitchen = new ApplicationUser
                {
                    UserName = KitchenEmail,
                    Email = KitchenEmail,
                    Name = "Kitchen"
                };
                IdentityResult result = userManager.CreateAsync
                    (userKitchen, KitchenPassword).Result;
                if (result.Succeeded)
                {
                    var kitchenClaim = new Claim("Kitchen", "Yes");
                    userManager.AddClaimAsync(userKitchen, kitchenClaim);
                }
            }
        public static void SeedRestaurant(UserManager<ApplicationUser> userManager)
        {

            const string RestaurantEmail = "Restaurant@localhost";
            const string RestaurantPassword = "Secret9/";

            var userRestaurant = new ApplicationUser
            {
                UserName = RestaurantEmail,
                Email = RestaurantEmail,
                Name = "Restaurant"
            };
            IdentityResult result3 = userManager.CreateAsync
                (userRestaurant, RestaurantPassword).Result;
            if (result3.Succeeded)
            {
                var restaurantClaim = new Claim("Restaurant", "Yes");
                userManager.AddClaimAsync(userRestaurant, restaurantClaim);
            }
        }
        public static void SeedReception(UserManager<ApplicationUser> userManager)
        {

            const string ReceptionEmail = "Reception@localhost";
            const string ReceptionPassword = "Secret00/";

            var userReception = new ApplicationUser
            {
                UserName = ReceptionEmail,
                Email = ReceptionEmail,
                Name = "Reception"
            };
            IdentityResult result4 = userManager.CreateAsync(userReception, ReceptionPassword).Result;
            if (result4.Succeeded)
            {
                var receptionClaim = new Claim("Reception", "Yes");
                userManager.AddClaimAsync(userReception, receptionClaim);
            }
        }
    }
}
