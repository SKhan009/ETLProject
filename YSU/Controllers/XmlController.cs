using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using YSU.Models;

namespace YSU.Controllers
{
    public class XmlController : Controller
    {
        private readonly MongoDbContext _dbContext;
        private readonly ILogger<XmlController> _logger;
        private List<RootTag> rootTags = new List<RootTag>();


        public XmlController(MongoDbContext dbContext, ILogger<XmlController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

            // Initialize rootTags in the constructor or load it from a data source
            rootTags = new List<RootTag>();

        }

        [HttpPost]
        public IActionResult Post(Award award)
        {
            _dbContext.Awards.InsertOne(award);
            return Ok();
        }

        [HttpGet]
        public IActionResult ReadXmlFiles(string searchTerm)
        {
            // Replace <username>, <password>, <cluster>, and <databaseName> with your actual MongoDB Atlas credentials
            var connectionStringRegular = "mongodb+srv://skhanusa21:Canon700D@cluster0.pba3oyh.mongodb.net/NSF";
            var dbContextRegular = new MongoDbContext(connectionStringRegular);

            // Replace <username>, <password>, <cluster>, and <databaseName> with your actual MongoDB Atlas credentials
            var connectionStringSCRAM = "mongodb+srv://skhanusa21:Canon700D@cluster0.pba3oyh.mongodb.net/NSF?authMechanism=SCRAM-SHA-1";
            var dbContextSCRAM = new MongoDbContext(connectionStringSCRAM);

            // Rest of your code for reading XML files and inserting into MongoDB
            string folderPath = @"/Users/saimakhan/ETLProject/YSU/bin/Debug/net7.0/XML";
            string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

           //Update this line to use the class-level rootTags

            rootTags = new List<RootTag>();

            // Call SearchSuggestions method to get search suggestions
            var searchResults = SearchSuggestions(searchTerm) as JsonResult;

            // Access the search suggestions from the JsonResult
            var suggestions = searchResults?.Value as List<RootTag>;

            foreach (string filePath in xmlFiles)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(RootTag));
                    RootTag rootTag = (RootTag)serializer.Deserialize(fs);

                        // Insert each Award into MongoDB if it exists
                        if (rootTag.Award != null)
                        {
                            dbContextRegular.Awards.InsertOne(rootTag.Award);
                            dbContextSCRAM.Awards.InsertOne(rootTag.Award);
                        }

                        // Add the deserialized object to the list
                        rootTags.Add(rootTag);
                    }
                
            }

            return View(rootTags);
        }

        public JsonResult SearchSuggestions(string searchTerm)
        {
            // Check if searchTerm is null or empty
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Return an empty list or handle as needed
                return Json(new List<RootTag>());
            }

            // Perform a search based on the searchTerm
            // This can include filtering the rootTags list based on your search logic

            var searchResults = rootTags
                .Where(tag =>
                    (tag.Award?.AwardTitle.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (tag.Award?.Institution?.StateCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false)
                )
                .ToList();

            return Json(searchResults);
        }


    }
} 
