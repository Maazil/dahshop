using System.Collections.Generic;
#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
#endif

namespace Dahshop.Models.SendModels
{
    public class SendItem : Item
    {
        #if NETCOREAPP
        [NotMapped]
        [Required]
        public List<IFormFile> Files { get; set; }
        #endif
        
        public SendItem(){}
    }
}