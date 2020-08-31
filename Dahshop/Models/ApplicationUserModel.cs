using Microsoft.AspNetCore.Identity;
#if NETCOREAPP
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif
namespace Dahshop.Models
{
    
    /// <summary>
    /// Create user data
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        // -------------  Necessary information  ---------------

        //First Name(s) of Customer
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        
        //Last Name(s) of Customer
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }


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
        public ApplicationUser()
        {
            FirstName = "";
            LastName = "";
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
        /// <param name="deliveryPostAddress"> Address of User to be delivered to </param>
        /// <param name="deliveryPostNumber"> Post Number of User to be delivered to, 4 Digits </param>
        /// <param name="deliveryPostPlace"> Town of User to be delivered to </param>
        /// <param name="itemSoldCount"> Count of items sold </param>
        /// <param name="followerCount"> Follower count of User </param>
        /// <param name="followingCount"> Following count of User </param>
        public ApplicationUser(string firstName, string lastName,
            string deliveryPostAddress, string deliveryPostNumber, 
            string deliveryPostPlace, int itemSoldCount,
            int followerCount, int followingCount)
        {
            FirstName = firstName;
            LastName = lastName;
            DeliveryPostAddress = deliveryPostAddress;
            DeliveryPostNumber = deliveryPostNumber;
            DeliveryPostPlace = deliveryPostPlace;
            ItemSoldCount = itemSoldCount;
            FollowerCount = followerCount;
            FollowingCount = followingCount;
        }

    }
}