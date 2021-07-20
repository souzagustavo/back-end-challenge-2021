using BackEndChallengeDotNet.Domain.Contracts;
using BackEndChallengeDotNet.Domain.Enums;
using BackEndChallengeDotNet.Domain.ObjectValues;
using System;

namespace BackEndChallengeDotNet.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(DateTime importedAt, string gender, Name name, Location location, string email, Login login, Dob dob, 
                Registered registered, string phone, string cell, Id id, Picture picture, string nat, EUserStatus status)
        {
            ImportedAt = importedAt;
            Gender = gender;
            Name = name;
            Location = location;
            Email = email;
            Login = login;
            Dob = dob;
            Registered = registered;
            Phone = phone;
            Cell = cell;
            Id = id;
            Picture = picture;
            Nat = nat;
            Status = status;

            Validate(new UserContract(this));
        }

        public User(string gender, Name name, Location location, string email, Login login, Dob dob,
                Registered registered, string phone, string cell, Id id, Picture picture, string nat, EUserStatus status) 
            : this(DateTime.Now, gender, name, location, email, login, dob, registered, phone, cell, id, picture, nat, status)
        {
        }

        public void SetStatus(EUserStatus status) => Status = status;
        public void SetId(string entityId) => EntityId = entityId;

        public DateTime ImportedAt { get; private set; }
        public string Gender { get; private set; }
        public Name Name { get; private set; }
        public Location Location { get; private set; }
        public string Email { get; private set; }
        public Login Login { get; private set; }
        public Dob Dob { get; private set; }
        public Registered Registered { get; private set; }
        public string Phone { get; private set; }
        public string Cell { get; private set; }
        public Id Id { get; private set; }
        public Picture Picture { get; private set; }
        public string Nat { get; private set; }
        public EUserStatus Status { get; private set; }
    }
}
