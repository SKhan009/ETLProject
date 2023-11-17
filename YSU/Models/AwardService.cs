using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace YSU.Models
{
    public class AwardService
    {
        private readonly IMongoCollection<Award> _awardsCollection;

        // Constructor for initializing the AwardService with MongoDB settings
        public AwardService(IOptions<NSFDatabaseSettings> awardDatabaseSettings)
        {
            // Create a MongoClient to connect to the MongoDB server
            var mongoClient = new MongoClient(awardDatabaseSettings.Value.ConnectionString);

            // Access the specified MongoDB database
            var mongoDatabase = mongoClient.GetDatabase(awardDatabaseSettings.Value.DatabaseName);

            // Access the collection within the database
            _awardsCollection = mongoDatabase.GetCollection<Award>(awardDatabaseSettings.Value.NSFCollectionName);
        }

        // Retrieve all awards asynchronously
        public async Task<List<Award>> GetAsync() =>
            await _awardsCollection.Find(_ => true).ToListAsync();

        // Retrieve a specific award by its ID asynchronously
       // public async Task<Award?> GetAsync(string id) =>
            //await _awardsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
