
using System.Collections.Generic;
using System.Net.Mime;
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
        public int ItemOwnerId { get; set; }
        
        // Name of item
        public string ItemName { get; set; }
        
        // Item description
        public string ItemDescription { get; set; }
        
        // Item size
        public string ItemSize { get; set; }
        
        // Item location
        public string ItemLocation { get; set; }
        
        // Item color
        public string ItemColor { get; set; }

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
            Sweater,
            Hoodie,
            Cardigan,
            Skirt,
            Dress,
            Shoes,
            Hats,
            Accessories,
            Makeup,
            Bikini,
            Shorts
        }
        
        // File path to the item 
        #if NETCOREAPP
        [Column("FilePath")]
        #endif
        public string FilePath { get; set; }
        //File connected to path
        
        
        /// <summary>
        /// Constructor for Items
        /// </summary>
        public Item()
        {
            ItemOwnerId = 0;
            ItemName = "";
            ItemDescription = "";
            ItemSize = "";
            ItemLocation = "";
            ItemColor = "";
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
        /// <param name="filePath">The filepath of the item</param>

        public Item(int ownerId, string name, string description, string size, string location, string color, string filePath)
        {
            ItemOwnerId = ownerId;
            ItemName = name;
            ItemDescription = description;
            ItemSize = size;
            ItemLocation = location;
            ItemColor = color;
            FilePath = filePath;
        }

    }
}