#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace Dahshop.Models
{
    
    /// <summary>
    /// Create Order table 
    /// </summary>
    /// 
    #if NETCOREAPP
    [Table("Orders")]
    #endif
    public class Order
    {
        
        // Order id
        #if NETCOREAPP
        [Key]
        #endif
        public int Id { get; set; }
        
        
        // Item Id
        public int ItemId { get; set; }

        // Customer Id ( if communication between the buyer and seller is needed ) 
        public int CustomerId { get; set; }
        
        //First Name of Customer
        public string FirstName { get; set; }
        
        //Last Name of Customer
        public string LastName { get; set; }
        
        //Phone Number of Customer
        public string PhoneNumber { get; set; }
        
        //Email of Customer
        public string Email { get; set; }
        
        
        // -------------  Delivery information  ---------------
        

        // Address of Customer to be delivered to
        public string DeliveryPostAddress { get; set; }
        
        // Post Number of Customer to be delivered to, 4 Digits
        public string DeliveryPostNumber { get; set; }
        
        // Town of Customer to be delivered to
        public string DeliveryPostPlace { get; set; }

        public enum OrderStatus
        {
            OrderConfirmed,
            PaymentConfirmed,
            OrderShipped,
            OrderArrived,
            ItemReceived,
            OrderCompleted
        }

    }
}