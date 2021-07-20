using BackEndChallengeDotNet.Domain.Enums;
using BackEndChallengeDotNet.Domain.ObjectValues;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BackEndChallengeDotNet.Persistance.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EntityId { get; set; }
        public DateTime ImportedAt { get; set; }
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public Registered Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public Id Id { get; set; }
        public Picture Picture { get; set; }
        public string Nat { get; set; }
        public EUserStatus Status { get; set; }

        public static implicit operator User(Domain.Entities.User domainEntity)
        {
            if (domainEntity == null)
                return null;

            return new User
            {
                EntityId = domainEntity.EntityId,
                ImportedAt = domainEntity.ImportedAt,
                Gender = domainEntity.Gender,
                Name = domainEntity.Name,
                Location = domainEntity.Location,
                Email = domainEntity.Email,
                Login = domainEntity.Login,
                Dob = domainEntity.Dob,
                Registered = domainEntity.Registered,
                Phone = domainEntity.Phone,
                Cell = domainEntity.Cell,
                Id = domainEntity.Id,
                Picture = domainEntity.Picture,
                Nat = domainEntity.Nat,
                Status = domainEntity.Status
            };
        }

        public static implicit operator Domain.Entities.User(User persistenceEntity)
        {
            if (persistenceEntity == null)
                return null;

            return new Domain.Entities.User(
                 importedAt: persistenceEntity.ImportedAt,
                 gender: persistenceEntity.Gender,
                 name: persistenceEntity.Name,
                 location: persistenceEntity.Location,
                 email: persistenceEntity.Email,
                 login: persistenceEntity.Login,
                 dob: persistenceEntity.Dob,
                 registered: persistenceEntity.Registered,
                 phone: persistenceEntity.Phone,
                 cell: persistenceEntity.Cell,
                 id: persistenceEntity.Id,
                 picture: persistenceEntity.Picture,
                 nat: persistenceEntity.Nat,
                 status: persistenceEntity.Status
                );
        }
    }
}
