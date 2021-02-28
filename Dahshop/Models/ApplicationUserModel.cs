using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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

        
        // ------------------  Profile data  ------------------

        // File for profile picture
        [NotMapped]
        public IFormFile ProfilePicture { get; set; }

        // File path for profile pitcure
        public string ProfilePictureFilePath{ get; set; }

        // User rating from other users
        public int UserRating { get; set; }

        // Count of items posted 
        public int ItemPostedCount { get; set; }
        
        // Count of items sold 
        public int ItemSoldCount { get; set; }

        // Count of followers
        public int FollowerCount { get; set; }
        
        // Count of people following
        public int FollowingCount { get; set; }

        // List of followers of this user
        [NotMapped]
        public List<ApplicationUser> listOfUserFollowers{ get;set; }

        // List of users this user is following
        [NotMapped]
        public List<ApplicationUser> listOfUsersFollowing{ get;set; }


        /// <summary>
        /// Empty constructor for User
        /// </summary>
        public ApplicationUser()
        {
            FirstName = "";
            LastName = "";
            UserRating = 0;
            ItemPostedCount = 0;
            ItemSoldCount = 0;
            FollowerCount = 0;
            FollowingCount = 0;
        }


        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="firstName"> First Name(s) of User </param>
        /// <param name="lastName"> Phone Number of User </param>
        /// <param name="itemSoldCount"> Count of items sold </param>
        /// <param name="followerCount"> Follower count of User </param>
        /// <param name="followingCount"> Following count of User </param>
        public ApplicationUser(string firstName, string lastName, int userRating, int itemPostedCount, int itemSoldCount, List<ApplicationUser> followers, List<ApplicationUser> following)
        {
            FirstName = firstName;
            LastName = lastName;
            UserRating = userRating;
            ItemPostedCount = itemPostedCount;
            ItemSoldCount = itemSoldCount;
            FollowerCount = followers.Count;
            FollowingCount = following.Count;
        }

    }
}