using System;
#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif
namespace Dahshop.Models
{
    /// <summary>
    /// Create Item table 
    /// </summary>
    #if NETCOREAPP
    [Table("Items")]
    #endif
    public class Item
    {
        
        // Item id
        #if NETCOREAPP
        [Key]
        #endif
        public int Id { get; set; }

        public ApplicationUser Owner { get; set; }

        // Item owner id
        public string OwnerId { get; set; }

        // Date of the item created
        public DateTime DateCreated { get;set; }
        public string DateCreatedString { get;set; }
        
        // Name of item
        public string Name { get; set; }
        
        // Item color
        public string Color { get; set; }
        
        // Item size
        public string Size { get; set; }
        
        // Item location
        public string Location { get; set; }
        
        // Item description
        public string Price { get; set; }
        
        // Item description
        public string Description { get; set; }

        // Item brand name
        public string BrandName { get; set; }

        // Is item a favorite
        public bool IsFavorite { get; set; } 

        // Status of item sold or not
        public bool IsSold { get; set; }

        // Category of the item
        public Category Category { get;set; }
        public int CategoryID { get; set;}

        
        // File path to the item 
        //#if NETCOREAPP
        //[Column("FilePath")]
        //#endif
        public string FilePath { get; set; }
        //File connected to path
        
        
        /// <summary>
        /// Constructor for Item
        /// </summary>
        public Item()
        {
            OwnerId = "";
            DateCreated = DateTime.Now;
            DateCreatedString = DateTime.Today.ToString("dd/MM/yyyy");
            Name = "";
            Color = "";
            Size = "";
            Location = "";
            Price = "";
            Description = "";
            BrandName = "";
            FilePath = "";
            IsFavorite = false;
            IsSold = false;
        }


        /// <summary>
        /// Constructor for Item
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="name">Name of the item</param>
        /// <param name="color">Item color</param>
        /// <param name="size">Size of item</param>
        /// <param name="location">Location of item</param>
        /// <param name="price">Item price</param>
        /// <param name="description"> Description of the item</param>
        /// <param name="brandname"> brand name of the item</param>
        /// <param name="filePath">The filepath of the item(s)</param>
        public Item(ApplicationUser user, string name, string color, string size, string location,  string price, string description, string brandname, Category category, string filePath)
        {
            Owner = user;
            OwnerId = user.Id;
            DateCreated = DateTime.Now;
            DateCreatedString = DateTime.Today.ToString("dd/MM/yyyy");
            Name = name;
            Color = color;
            Size = size;
            Location = location;
            Price = price;
            Description = description;
            BrandName = brandname;
            FilePath = filePath;
            IsFavorite = false;
            IsSold = false;
            Category = category;
            CategoryID = category.Id;
        }

    }
}