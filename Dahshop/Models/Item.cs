#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif
namespace Dahshop.Models
{
    /// <summary>
    /// Create Item data 
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

        // Status of item sold or not
        public enum ItemStatus
        {
            Available,
            Sold
        }
        
        // Item description
        //public string ItemColor { get; set; }
        
        
        // User who orders the item
        #if NETCOREAPP
        [NotMapped]
        #endif
        public AppUser AppUser { get; set; }
        
        public int CustomerId { get; set; }

    }
}