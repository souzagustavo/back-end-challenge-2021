using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.Facades
{
    public interface IRandomUserService
    {
        public Task PopulateDatabaseAsync(int countPage = 100);
    }
}