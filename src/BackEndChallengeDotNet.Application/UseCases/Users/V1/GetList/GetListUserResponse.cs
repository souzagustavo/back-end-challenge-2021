using BackEndChallengeDotNet.Application.Notifications;
using BackEndChallengeDotNet.Application.ViewModels;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndChallengeDotNet.Application.UseCases.Users.V1.GetList
{
    public class GetListUserResponse : Result
    {
        public GetListUserResponse() : base(Enumerable.Empty<Notification>().ToList())
        {
        }

        public GetListUserResponse(IReadOnlyCollection<Notification> notifications) : base(notifications)
        {
        }

        public UserViewModel[] Users { get; set; } = Array.Empty<UserViewModel>();
        public long Total { get; set; }
    }
}
