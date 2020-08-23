using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Dahshop.Models;

namespace Dahshop.Data
{
    public class ApplicationDbInitializer
    {
        /// <summary>
        /// Application Database Initializer
        /// Function for initializing database
        /// </summary>
        /// <param name="db"> Database context </param>
        /// <param name="um"> User Manager </param>
        /// <param name="rm"> Role Manager </param>
        /// <param name="development"> In development bool</param>
        public static void Initialize(ApplicationDbContext db, UserManager<IdentityUser> um,
            RoleManager<IdentityRole> rm, bool development)
        {
            
            // Run migrations if we're not in development mode
            if (!development)
            {
                //Migration is commented out since we do not have any yet.
                //db.Database.Migrate();
                //return;
            }
            else
            {
                // Delete the database before we initialize it. This is common to do during development.
                db.Database.EnsureDeleted();

                // Make sure the database and tables exist
                db.Database.EnsureCreated();
                
                // Admin Role
                var adminRole = new IdentityRole("Admin");
                rm.CreateAsync(adminRole).Wait();

                db.SaveChanges();

                // Admin users
                var admin = new IdentityUser();
                admin.UserName = "admin@uia.no";
                admin.Email = "admin@uia.no";
                admin.EmailConfirmed = true;
                
                um.CreateAsync(admin, "Password1.").Wait();
                um.AddToRoleAsync(admin, "Admin").Wait();

                // Save users
                db.SaveChanges();
                
                // Look for users
                if (db.AppUsers.Any())
                {
                    return;
                }
                
                // Create users
                var appUser = new AppUser[]
                {
                    
                    new AppUser
                    {
                        FirstName = "Dah Dah", LastName = "Ry", PhoneNumber = "41272567",
                        Email = "dahdahry@gmail.com", DeliveryPostAddress = "Svegeveien 2A", 
                        DeliveryPostNumber = "4400", DeliveryPostPlace = "Flekkefjord", ItemSoldCount = 0,
                        FollowerCount = 0, FollowingCount = 0
                    }, 
                    
                    new AppUser
                    {
                        FirstName = "Ling", LastName = "Shing", PhoneNumber = "91378255",
                        Email = "liishi@gmail.com", DeliveryPostAddress = "Innersvingen 5", 
                        DeliveryPostNumber = "4289", DeliveryPostPlace = "Froland", ItemSoldCount = 0,
                        FollowerCount = 0, FollowingCount = 0
                    },

                };
                
                
                db.AppUsers.AddRange(appUser);
                db.SaveChanges();

            }
            
        }
    }
}