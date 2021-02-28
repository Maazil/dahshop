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
    [Table("Categories")]
    #endif
    public class Category
    {
        // Item id
        #if NETCOREAPP
        [Key]
        #endif
        public int Id { get; set; }

        public string Name{ get; set; }

        public Category(){}

        public Category(string name)
        {
            Name = name;
        }

    }

}