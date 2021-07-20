using BackEndChallengeDotNet.Application.Notifications;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.Put
{
    public class PutUserResponse : Result
    {
        public PutUserResponse() : base(Enumerable.Empty<Notification>().ToList())
        {
        }

        public PutUserResponse(IReadOnlyCollection<Notification> notifications) : base(notifications)
        {
        }
    }
}
