#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace Dahshop.Models
{
    
    /// <summary>
    /// All information needed about a customer
    /// </summary>
    #if NETCOREAPP
    [Table("Customers")]
    #endif
    public class Customer
    {
        //Id
        #if NETCOREAPP
        [Key]
        #endif
        public int Id { get; set; }
        
        //Address of Customer to be delivered to
        public string DeliveryPostAddress { get; set; }
        
        //Post Number of Customer to be delivered to, 4 Digits
        public string DeliveryPostNumber { get; set; }
        
        //Town of Customer to be delivered to
        public string DeliveryPostPlace { get; set; }
        
        //Email of Customer
        public string Email { get; set; }
        
        //First Name(s) of Customer
        public string FirstName { get; set; }
        
        //Last Name(s) of Customer
        public string LastName { get; set; }
        
        //Phone Number of Customer
        public string PhoneNumber { get; set; }
        
        //Living Address of Customer, where they live
        //Not always same as where they want the garage
        public string PostAddress { get; set; }
        
        //Post Number of Customer, where they live
        public string PostNumber { get; set; }
        
        //Town of Customer, where they live
        public string PostPlace { get; set; }

        /// <summary>
        /// Constructor for Customer
        /// </summary>
        public Customer()
        {
            this.DeliveryPostAddress = "";
            this.DeliveryPostNumber = "";
            this.DeliveryPostPlace = "";
            this.Email = "";
            this.FirstName = "";
            this.LastName = "";
            this.PhoneNumber = "";
            this.PostAddress = "";
            this.PostNumber = "";
            this.PostPlace = "";
        }

        
        /// <summary>
        /// Constructor for Customer
        /// </summary>
        /// <param name="deliveryPostAddress"> Address of Customer to be delivered to </param>
        /// <param name="deliveryPostNumber">Post Number of Customer to be delivered to, 4 Digits</param>
        /// <param name="deliveryPostPlace">Town of Customer to be delivered to</param>
        /// <param name="email">Email of Customer</param>
        /// <param name="firstName">First Name(s) of Customer</param>
        /// <param name="lastName">Phone Number of Customer</param>
        /// <param name="phoneNumber">Phone Number of Customer</param>
        /// <param name="postAddress">Living Address of Customer</param>
        /// <param name="postNumber">Post Number of Customer</param>
        /// <param name="postPlace">Town of Customer</param>
        public Customer(string deliveryPostAddress, string deliveryPostNumber, string deliveryPostPlace, string email, string firstName, string lastName, string phoneNumber, string postAddress, string postNumber, string postPlace)
        {
            this.DeliveryPostAddress = deliveryPostAddress;
            this.DeliveryPostNumber = deliveryPostNumber;
            this.DeliveryPostPlace = deliveryPostPlace;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.PostAddress = postAddress;
            this.PostNumber = postNumber;
            this.PostPlace = postPlace;
        }
    }
}