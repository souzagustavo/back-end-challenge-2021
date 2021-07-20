using BackEndChallengeDotNet.Application.DTOs;
using BackEndChallengeDotNet.Domain.Enums;
using System;

namespace BackEndChallengeDotNet.Application.ViewModels
{
    public class UserViewModel : User
    {
        public string EntityId { get; set; }
        public DateTime ImportedAt { get; set; }
        public EUserStatus Status { get; set; }
    }
}
