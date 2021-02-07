using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dahshop.Data;
using Dahshop.Models;
using Dahshop.Models.SendModels;
using Microsoft.AspNetCore.Http;

namespace Dahshop.Controllers
{
    
    /// <summary>
    /// The Resource Api Controller
    /// </summary>
    /// <remarks>
    /// <para>This class job is to control all functionality that have with files on the server.</para>
    /// </remarks>

    public class ResourceApiController : ControllerBase
    {
        // File path definers: 
        private const string _mainPath = "wwwroot/resources";
        private const string _mainUrl = "/resources";
        private const string _dbFiles = "/databaseFiles";
        private const string _deletePath = "wwwroot";
        private const string _items = _dbFiles + "/items";
        
        
        //Filepath and fileUrls for the different types. 
        private const string ItemsPath = _mainPath + _items;
        private const string ItemsUrl = _mainUrl + _items;
        
        // The database variable. 
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Resource Api Controllers Constructor
        /// </summary>
        /// <param name="db">The database context you want it to use.</param>
        public ResourceApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        
        /// <summary>
        /// Store item file on the server.
        /// </summary>
        /// <returns>Returns a bool if it can save it on the server. </returns>
        /// See <see cref="StoreFile"/> on how it adds a file.
        /// <param name="item">The item it should store</param>
        /// <param name="id">The id it has in the database. Used for giving it a unique id. </param>
        public async Task<bool> StoreItem(SendItem item, int id)
        {
            if (_db.Items.Any(x => x.Id == id))
            {
                //Calls the delete function
                await DeleteFile(item.FilePath);
            }
            
            //Try to store the file. We receive the filepath back. 
            var filePath = await StoreFile(ItemsUrl, ItemsPath, item.Files, id);

            //If the filepath is empty it could not add it. 
            if (filePath == "")
            {
                //Return false because it failed
                return false;
            }

            // Since we succeed, set the new filepath.  
            item.FilePath = filePath;
            
            // Empty file field for safety with sending back.
            item.Files = null;

            // return true since it could add the file.  
            return true;
        }
        
        
        
        
         /// <summary>
        /// Store file on the server.
        /// Ps. The path and url should be linking to the same place just with different starting point. 
        /// </summary>
        /// <returns>Returns a string with the path to the object. If it fails the path will be "" </returns>
        /// <param name="url">The url where it is going to find the file.</param>
        /// <param name="path">The path it is going to use to store the file at the correct place.</param>
        /// <param name="files">The file it should store</param>
        /// <param name="id">The id it has in the database. Used for giving it a unique id. </param>
        private async Task<string> StoreFile(string url,string path, List<IFormFile> files, int id)
        {
            //Variable to store the fileUrl in. 
            var fileUrl = "";
            var directoryPath = path + "/" + id;
            Directory.CreateDirectory(directoryPath);
            
            // Check that file is not empty
            if (files.Count > 0)
            {
                //The file extension.
                foreach(var f in files)
                {   
                    var fileExtension = f.FileName.Split(".")[1];
                    
                    // Check file formats
                    if (fileExtension == "jpg" || fileExtension == "jpeg" || fileExtension == "png" )
                    {
                        // The filepath we use to retrieve it. The one in database
                        fileUrl += url + "/" + id+'/'+ f.FileName+',';
                        
                        // The actual filepath. 
                        var filePath = directoryPath + "/"+ f.FileName;
                        
                        //Copy the file with a file stream. 
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await f.CopyToAsync(stream);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File type is not accepted");
                    }
                    
                }            
            }
            
            // If file url ends with a comma, then remove it
            if (fileUrl.EndsWith(",")) {
                fileUrl = fileUrl.Substring(0, fileUrl.Length - 1);
            }

            //Return the fileUrl
            return fileUrl;
        }

         

         //Delete file from the directory after being edited or deleted
         public async Task<bool> DeleteFile(string filePath)
         {
             //Sets the filepath into lists
             var listOfPaths = filePath.Split(",");
            
             //If the filepath is empty, there is something wrong
             if (filePath == "")
             {
                 return false;
             }
            
             //Loops trough the list and delete the paths
             foreach (var s in listOfPaths)
             {
                 //The delete path + the file path
                 var deletePath = _deletePath + s;
                
                 // Try catch, in case something goes wrong
                 try
                 {
                     //Delete the file from the directory
                     System.IO.File.Delete(deletePath);
                
                 }
                 catch(IOException io)
                 {
                     Console.WriteLine($"Couldn't delete the path'{io}'");
                 }
             }
            
             //Return true if everything works as intended
             return true;
         }
         
         
         
         
    }// public class controller
    
}