using BackEndChallengeDotNet.Domain.Entities;
using BackEndChallengeDotNet.Domain.Interfaces;
using BackEndChallengeDotNet.Persistance.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Persistance.Commands
{
    public class UserRepository : RepositoryBase<Entities.User>, IUserRepository
    {
        public UserRepository(MongoDbContext mongoDbContext) : base(mongoDbContext, "users")
        {
        }

        public async Task<string> InsertAsync(User user)
        {
            var collection = GetCollection();

            await collection.InsertOneAsync(user);
            return user.EntityId;
        }

        public async Task<User> GetAsync(string entityId)
        {
            var collection = GetCollection();

            var cursor = await collection.FindAsync(GetFilterById(entityId));
            return
                await cursor.FirstOrDefaultAsync();
        }

        public async Task<(long total, IEnumerable<User> results)> GetAllPagedAsync(int pageSize, int pageNumber)
        {
            var collection = GetCollection();

            var total = await collection.CountDocumentsAsync(Builders<Entities.User>.Filter.Empty);

            var cursor = collection
                            .Find(_ => true)
                            .Skip(pageSize * (pageNumber - 1))
                            .Limit(pageNumber);

            var results = await cursor.ToListAsync();

            return
                (total, results
                    .Select<Entities.User,User>( x => x));
        }

        public async Task<bool> DeleteAsync(string entityId)
        {
            var collection = GetCollection();

            var result = await collection.DeleteOneAsync(GetFilterById(entityId));
            return 
                result.DeletedCount > 0;
        }

        public async Task<bool> ReplaceAsync(User user)
        {
            var collection = GetCollection();

            var result = await collection.ReplaceOneAsync(GetFilterById(user.EntityId), user);
            return 
                result.IsModifiedCountAvailable;
        }

        private FilterDefinition<Entities.User> GetFilterById(string id)
        {
            if (!ObjectId.TryParse(id, out _))
                return Builders<Entities.User>.Filter.Empty;

            return Builders<Entities.User>.Filter.Eq(u => u.EntityId, id);
        }
    }
}
