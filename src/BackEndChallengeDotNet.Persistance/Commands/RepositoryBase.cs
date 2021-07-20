using BackEndChallengeDotNet.Persistance.Context;
using MongoDB.Driver;

namespace BackEndChallengeDotNet.Persistance.Commands
{
    public abstract class RepositoryBase<TEntity>
    {
        protected readonly string _collectionName;
        protected readonly IMongoDatabase _db;

        protected RepositoryBase(MongoDbContext mongoDbContext, string collectionName)
        {
            _db = mongoDbContext.MongoClient.GetDatabase(mongoDbContext.DatabaseName);
            _collectionName = collectionName;
        }

        protected IMongoCollection<TEntity> GetCollection()
            => _db.GetCollection<TEntity>(_collectionName);
    }
}
