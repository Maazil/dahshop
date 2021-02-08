using System;
using System.Linq;
using System.Threading.Tasks;
using Dahshop.Data;
using Dahshop.Models;
using Dahshop.Models.SendModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Dahshop.Controllers
{
    
    /// <summary>
    /// The Server Api Controller
    /// </summary>
    /// <remarks>
    /// <para>This class job is to control all communication from client to server.</para>
    /// </remarks>
    [ApiController]
    [Route("api/server")]
    public class ServerApiController : ControllerBase
    {
        
        //String separator
        //private string _stringSeperator = ",";

        //Database and user manager        
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ResourceApiController _rs;

        /// <summary>
        /// Server Api Controllers Constructor
        /// </summary>
        /// <param name="db">The database context you want it to use.</param>
        /// <param name="userManager">The user manager it is going to use.</param>
        public ServerApiController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _rs = new ResourceApiController(_db);
        }
        
        
        /*********************** GET *************************/

        /// <summary>
        ///  GET - All Items
        /// </summary>
        /// <returns> All Items from the database.</returns>
        /// <response code="200">Returns OK if everything works as intended</response>
        /// <response code="404">If the item doesn't exist</response>  
        [HttpGet("items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllItems()
        {
            //Get all materials
            var items = _db.Items;
                 
            //Check if the items exists, return 404 if it doesn't
            if (items == null)
                return NotFound();

            return Ok(items);
        }
        
        
        
        /// <summary>
        ///  GET -  Item based on id
        /// </summary>
        /// <returns> A specific item from the database.</returns>
        /// <param name="id">The id to the item</param>
        /// <response code="200">Returns OK if everything works as intended</response>
        /// <response code="404">If the item doesn't exist</response> 
        [HttpGet("items/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetItem(int id)
        {
            //Search for the given structure
            var item = _db.Items.Find(id);
                 
            //Check if the structure exists, return 404 if it doesn't
            if (item == null)
                return NotFound();
            
            return Ok(item);
        }
        
        
        
        /*********************** POST *************************/
        
        /// <summary>
        ///  POST - An item
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Item
        ///     {
        ///        "id": 0,
        ///        "name": "Item 1",
        ///        "color": "Red",
        ///        "size": "M",
        ///         "location": "Oslo",
        ///         "price": "200",
        ///         "description": "New",
        ///        "filePath": "",
        ///        "file": File
        ///     }
        ///
        /// </remarks>
        /// <returns> The item that was added to the database.</returns>
        /// <param name="item">The item we are going to add.</param>
        /// <response code="200">Returns OK if everything works as intended</response>
        /// <response code="400">If Id isn't 0</response>
        [Authorize]
        [HttpPost("items")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostItem([FromForm] SendItem item)
        {
            //Check if the material have another id then 0
            if (item.Id != 0)
            {
                //If it is, id is something else tell them something is wrong. 
                //This is added for error check from the front-end. 
                return BadRequest();
            }
            
            Console.WriteLine("Item name: " + item.Name);

            //Check if the item model is valid 
            // If model was not valid. Then it is a bad request. 
            if (!ModelState.IsValid) return BadRequest();
            
            // If 
            // Check for if the file is null. 
            // if it is then not valid item.
            if (item.Files == null)
            {
                return BadRequest();
            }
                
            // Try to store the file on the correct place on server
            // Get the count of all values in database to get the next id.
            // Since we need the id before it is added in the database.
            // If it fail it is a bad request. 
            if (await _rs.StoreItem(item, _db.Items.Count() + 1) == false)
            {
                return BadRequest();
            }

            // Set ownerId to the item
            // Get user id from the user logged in
            var user = _userManager.GetUserId(User);
            Console.WriteLine("User Id: " + user + " - is logged in!");

            item.OwnerId = user;

            //Add material to database and saves it
            _db.Add(item);
            _db.SaveChanges();

            
            
            var newItem = new Item(user, item.Name, item.Color, item.Size, item.Location, item.Price, item.Description, item.FilePath)
            {
                Id = item.Id,
            };
                
            //Return the object back
            return Ok(newItem);

        }
        
        
        
        /*********************** PUT *************************/

        
        
        
        
        /*********************** DELETE *************************/

        
        
        
    }
}