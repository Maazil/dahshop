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
        
        // Item owner id
        public string OwnerId { get; set; }
        
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

        // Is item a favorite
        public bool IsFavorite { get; set; }

        // Status of item sold or not
        public enum ItemStatus
        {
            Available,
            Sold
        }
        
        public enum ItemCategories
        {
            Jeans,
            Pants,
            Jacket,
            Tshirt,
            Sweater,
            Hoodie,
            Cardigan,
            Skirt,
            Dress,
            Shoes,
            Hats,
            Accessories,
            Makeup,
            Swimsuit,
            Shorts
            
        }
        
        // File path to the item 
        //#if NETCOREAPP
        //[Column("FilePath")]
        //#endif
        public string FilePath { get; set; }
        //File connected to path
        
        
        /// <summary>
        /// Constructor for Items
        /// </summary>
        public Item()
        {
            OwnerId = "";
            Name = "";
            Color = "";
            Size = "";
            Location = "";
            Price = "";
            Description = "";
            FilePath = "";
        }


        /// <summary>
        /// Constructor for Items
        /// </summary>
        /// <param name="ownerId">Size of item</param>
        /// <param name="name">Name of materials, displayed for the users in the program</param>
        /// <param name="description"> Description of the item</param>
        /// <param name="size">Size of item</param>
        /// <param name="location">Location of item</param>
        /// <param name="color">Item color</param>
        /// <param name="price">Item price</param>
        /// <param name="filePath">The filepath of the item</param>
        public Item(ApplicationUser user, string name, string color, string size, string location,  string price, string description, string filePath)
        {
            OwnerId = user.Id;
            Name = name;
            Color = color;
            Size = size;
            Location = location;
            Price = price;
            Description = description;
            FilePath = filePath;
        }

    }
}