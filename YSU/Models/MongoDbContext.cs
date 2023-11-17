using MongoDB.Driver;


namespace YSU.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("NSF");
        }

        public IMongoCollection<Award> Awards => _database.GetCollection<Award>("award");
        // Add other collections as needed
    }
}
