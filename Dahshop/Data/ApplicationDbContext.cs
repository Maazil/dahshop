using System;
using System.Collections.Generic;
using System.Text;
using Dahshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dahshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        
        // create set of users
        public DbSet<AppUser> AppUsers { get; set; }
        
        // Create set of items
        public DbSet<Item> Items { get; set; }
        
        // Create set of orders
        public DbSet<Order> Orders { get; set; }
        
    }
}
