using MongoDB.Driver;

namespace BackEndChallengeDotNet.Persistance.Context
{
    public class MongoDbContext
    {
        public MongoDbContext(MongoUrl mongoUrl)
        {
            MongoUrl = mongoUrl;
            MongoClient = new MongoClient(mongoUrl);
        }
        private MongoUrl MongoUrl { get; }
        public MongoClient MongoClient { get; }
        public string DatabaseName { get => MongoUrl.DatabaseName; }
    }
}
