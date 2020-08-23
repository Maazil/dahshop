#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif
namespace Dahshop.Models
{
    
    /// <summary>
    /// Create user data and table
    /// </summary>
    #if NETCOREAPP
    [Table("Users")]
    #endif
    public class AppUser
    {
        // -------------  Necessary information  ---------------
        
        // User id
        #if NETCOREAPP
        [Key]
        #endif
        public int Id { get; set; }

        //First Name(s) of Customer
        public string FirstName { get; set; }
        
        //Last Name(s) of Customer
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
        
        
        
        // ------------------  Profile data  ------------------
        
        // Count of items sold 
        public int ItemSoldCount { get; set; }

        // Count of followers
        public int FollowerCount { get; set; }
        
        // Count of people following
        public int FollowingCount { get; set; }


        /// <summary>
        /// Empty constructor for User
        /// </summary>
        public AppUser()
        {
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            Email = "";
            DeliveryPostAddress = "";
            DeliveryPostNumber = "";
            DeliveryPostPlace = "";
            ItemSoldCount = 0;
            FollowerCount = 0;
            FollowingCount = 0;
        }


        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="firstName"> First Name(s) of User </param>
        /// <param name="lastName"> Phone Number of User </param>
        /// <param name="phoneNumber"> Phone Number of User </param>
        /// <param name="email"> Email of Customer </param>
        /// <param name="deliveryPostAddress"> Address of User to be delivered to </param>
        /// <param name="deliveryPostNumber"> Post Number of User to be delivered to, 4 Digits </param>
        /// <param name="deliveryPostPlace"> Town of User to be delivered to </param>
        /// <param name="itemSoldCount"> Count of items sold </param>
        /// <param name="followerCount"> Follower count of User </param>
        /// <param name="followingCount"> Following count of User </param>
        public AppUser(string firstName, string lastName, string phoneNumber, string email,
            string deliveryPostAddress, string deliveryPostNumber, string deliveryPostPlace,
            int itemSoldCount, int followerCount, int followingCount)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            DeliveryPostAddress = deliveryPostAddress;
            DeliveryPostNumber = deliveryPostNumber;
            DeliveryPostPlace = deliveryPostPlace;
            ItemSoldCount = itemSoldCount;
            FollowerCount = followerCount;
            FollowingCount = followingCount;
        }

    }
}