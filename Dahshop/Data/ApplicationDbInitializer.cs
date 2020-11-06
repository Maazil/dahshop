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
            }


            if (!db.Items.Any(s => s.Name.Equals("TestItem")))
            {
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
                
                // New user
                var user1 = new IdentityUser();
                user1.UserName = "mkling@uia.no";
                user1.Email = "mkling@uia.no";
                user1.EmailConfirmed = true;

                um.CreateAsync(user1, "Password1.").Wait();

                db.SaveChanges();


                // Add test Item
                var item1 = new Item(
                    admin.Id, 
                    "Spring dress",
                    "Hvit", 
                    "S",
                    "Kristiansand", 
                    "500", 
                    "Fin dress for vår",
                    "/resources/databaseFiles/items/1/flora-dress1.jpg," +
                    "/resources/databaseFiles/items/1/flora-dress2.jpg," +
                    "/resources/databaseFiles/items/1/flora-dress3.jpg," +
                    "/resources/databaseFiles/items/1/flora-dress4.jpg");

                db.Add(item1);
                db.SaveChanges();
                
                var item2 = new Item(
                    user1.Id,
                    "Høst hoodie",
                    "Gul",
                    "M", 
                    "Oslo",
                    "200",
                    "Brukt hoodie",
                    "/resources/databaseFiles/items/2/Hoodie1.jpg," +
                    "/resources/databaseFiles/items/2/Hoodie2.jpg," +
                    "/resources/databaseFiles/items/2/Hoodie3.jpg");
                
                db.Add(item2);
                db.SaveChanges();

            }// If !Any items
            
        }// Initialize
    }
}