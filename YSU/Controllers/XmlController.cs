using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YSU.Models;

namespace YSU.Controllers
{
    public class XmlController : Controller
    {
        private readonly MongoDbContext _dbContext;
        private readonly ILogger<XmlController> _logger;

        // Constructor to inject the MongoDbContext and ILogger
        public XmlController(MongoDbContext dbContext, ILogger<XmlController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(Award award)
        {
            // Insert the Award into the MongoDB collection
            _dbContext.Awards.InsertOne(award);

            // Return Ok if the operation is successful
            return Ok();
        }

        [HttpGet]
        public IActionResult ReadXmlFiles()
        {
            string folderPath = @"/Users/saimakhan/ETLProject/YSU/bin/Debug/net7.0/XML";

            // Get all XML files in the specified folder
            string[] xmlFiles = Directory.GetFiles(folderPath, "*.xml");

            // Create a list to store the deserialized objects
            List<RootTag> rootTags = new List<RootTag>();

            // Deserialize each XML file
            foreach (string filePath in xmlFiles)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(RootTag));
                    RootTag rootTag = (RootTag)serializer.Deserialize(fs);

                    rootTags.Add(rootTag);
                }
            }

            return View(rootTags);
        }

    }
}



