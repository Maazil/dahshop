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
                var admin = new IdentityUser
                {
                    UserName = "admin@uia.no", Email = "admin@uia.no", EmailConfirmed = true
                };

                um.CreateAsync(admin, "Password1.").Wait();
                um.AddToRoleAsync(admin, "Admin").Wait();

                // Save users
                db.SaveChanges();
            }
            
        }
    }
}