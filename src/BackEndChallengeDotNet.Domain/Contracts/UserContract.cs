using BackEndChallengeDotNet.Domain.Entities;
using Flunt.Validations;
using System;

namespace BackEndChallengeDotNet.Domain.Contracts
{
    public class UserContract : Contract<User>
    {
        public UserContract(User user)
        {
            Requires()
            .IsGreaterThan(user.ImportedAt, DateTime.MinValue, nameof(user.ImportedAt), "Invalid date");
        }
    }
}
