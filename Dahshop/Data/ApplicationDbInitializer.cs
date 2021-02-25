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
        public static void Initialize(ApplicationDbContext db, UserManager<ApplicationUser> um,
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
                
                // Admin user
                var admin = new ApplicationUser();
                admin.UserName = "admin@uia.no";
                admin.Email = "admin@uia.no";
                admin.EmailConfirmed = true;
                
                um.CreateAsync(admin, "Password1.").Wait();
                um.AddToRoleAsync(admin, "Admin").Wait();

                // Save users
                db.SaveChanges();

                // New user
                var matthew = new ApplicationUser("Matthew", "Ling", 0, 0, 0, new List<ApplicationUser>(), new List<ApplicationUser>())
                {
                    UserName = "mkling@uia.no",
                    Email = "mkling@uia.no",
                    EmailConfirmed = true,
                    PhoneNumber = "41378793",
                    PhoneNumberConfirmed = true
                };
                
                um.CreateAsync(matthew, "Password1.").Wait();
                // Save user
                db.SaveChanges();


                // Dah dah User
                var dahdah = new ApplicationUser("Dah Dah", "Ry", 0, 0, 0, new List<ApplicationUser>(), new List<ApplicationUser>())
                {
                    UserName = "dahdah@uia.no",
                    Email = "dahdah@uia.no",
                    EmailConfirmed = true
                };
                
                um.CreateAsync(dahdah, "Password1.").Wait();
                // Save user
                db.SaveChanges();


                // Lawnar user
                var lawnar = new ApplicationUser("Lawnar", "Ry", 0, 0, 0, new List<ApplicationUser>(), new List<ApplicationUser>())
                {
                    UserName = "lawnar@uia.no",
                    Email = "lawnar@uia.no",
                    EmailConfirmed = true
                };
                
                um.CreateAsync(lawnar, "Password1.").Wait();
                // Save user
                db.SaveChanges();


                // Cabriella user
                var cabriella = new ApplicationUser("Cabriella", "Sein Ya", 0, 0, 0, new List<ApplicationUser>(), new List<ApplicationUser>())
                {
                    UserName = "cabriella@uia.no",
                    Email = "cabriella@uia.no",
                    EmailConfirmed = true
                };
                
                um.CreateAsync(cabriella, "Password1.").Wait();
                // Save user
                db.SaveChanges();


                // Add test Item
                var item1 = new Item(
                    admin,
                    "Spring dress",
                    "Hvit",
                    "S",
                    "Kristiansand",
                    "500",
                    "Fin dress for vår",
                    "/resources/databaseFiles/items/1/flora-dress1.jpg");
                    // "/resources/databaseFiles/items/1/flora-dress2.jpg," +
                    // "/resources/databaseFiles/items/1/flora-dress3.jpg," +
                    // "/resources/databaseFiles/items/1/flora-dress4.jpg");

                db.Add(item1);
                db.SaveChanges();
                
                var item2 = new Item(
                    matthew,
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