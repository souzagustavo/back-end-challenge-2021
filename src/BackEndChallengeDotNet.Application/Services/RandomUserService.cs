using AutoMapper;
using BackEndChallengeDotNet.Application.ApiClients;
using BackEndChallengeDotNet.Domain.Entities;
using BackEndChallengeDotNet.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.Facades
{
    public class RandomUserService : IRandomUserService
    {
        private const int maxImportAllowed = 2000;
        private readonly IRandomUserClient _randomUserClient;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RandomUserService> _logger;
        private readonly IMapper _mapper;

        public RandomUserService(IRandomUserClient randomUserClient, IUserRepository userRepository, ILogger<RandomUserService> logger, IMapper mapper)
        {
            _randomUserClient = randomUserClient;
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task PopulateDatabaseAsync(int pageSize = 100)
        {
            _logger.LogInformation("Populating users on database");

            if (pageSize <= 0)
                throw new ArgumentException($"Cannot be equal or less than zero", nameof(pageSize));

            var remainder = (maxImportAllowed % pageSize);
            if (remainder != 0)
                throw new ArgumentException($"Unable to calculate buffer! The number must be divisible by '{maxImportAllowed}'", nameof(pageSize));

            double buffer = (maxImportAllowed / pageSize);
            for (int page = 1; page <= buffer; page++)
            {
                var response = await _randomUserClient.GetPaginationAsync(page: page, results: pageSize);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"It was not possible to get users in API");
                    continue;
                }

                foreach (var user in response.Content.Results)
                {
                    var mappedToEntity = _mapper.Map<User>(user);
                    var id = await _userRepository.InsertAsync(mappedToEntity);
                    _logger.LogInformation($"User imported. Id: {id}");
                }
            }

            _logger.LogInformation("Finished");
        }
    }
}
