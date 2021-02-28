using System;
using System.Collections.Generic;
using System.Text;
using Dahshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dahshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        
        // Users
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        // Create set of items
        public DbSet<Item> Items { get; set; }
        
    }
}
