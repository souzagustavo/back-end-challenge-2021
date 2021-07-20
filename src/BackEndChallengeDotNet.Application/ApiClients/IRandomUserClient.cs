using BackEndChallengeDotNet.Application.ApiClients.Response;
using Refit;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.ApiClients
{    
    public interface IRandomUserClient
    {
        [Get("/api")]
        Task<ApiResponse<UsersResponse>> GetPaginationAsync([Query("page")] int page, [Query("results")] int results);
    }
}
