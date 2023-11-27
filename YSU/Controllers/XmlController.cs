using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using YSU.Models;

namespace YSU.Controllers
{
    public class XmlController : Controller
    {
        private readonly MongoDbContext _dbContext;
        private readonly ILogger<XmlController> _logger;

        public XmlController(MongoDbContext dbContext, ILogger<XmlController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(Award award)
        {
            _dbContext.Awards.InsertOne(award);
            return Ok();
        }

        [HttpGet]
        public IActionResult ReadXmlFiles()
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

            List<RootTag> rootTags = new List<RootTag>();

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
            // Filter rootTags based on the searchInstitution parameter
            if (!string.IsNullOrEmpty(searchState))
            {
                rootTags = rootTags
                    .Where(rt => rt.Award != null &&
                                 rt.Award.Institution != null &&
                                 rt.Award.Institution.StateName != null &&
                                 rt.Award.Institution.StateName.Contains(searchState))
                    .ToList();
            }


            return View(rootTags);
        }
    }
}
