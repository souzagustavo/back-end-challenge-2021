using BackEndChallengeDotNet.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<string> InsertAsync(User user);
        Task<User> GetAsync(string entityId);
        Task<(long total, IEnumerable<User> results)> GetAllPagedAsync(int pageSize, int pageNumber);
        Task<bool> DeleteAsync(string entityId);
        Task<bool> ReplaceAsync(User user);
    }
}
