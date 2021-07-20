using AutoMapper;
using BackEndChallengeDotNet.Application.UseCases.Users.V1.Put;
using BackEndChallengeDotNet.Application.ViewModels;
using BackEndChallengeDotNet.Domain.Entities;
using BackEndChallengeDotNet.Domain.ObjectValues;
using System.Diagnostics.CodeAnalysis;

namespace BackEndChallengeDotNet.API.AutoMappers
{
    [ExcludeFromCodeCoverage]
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMapDTOsToEntities();
            CreateMapEntitiesToDTOs();
            CreateMapEntitiesToViewModel();
            CreateMapViewModelToEntities();
        }

        private void CreateMapEntitiesToDTOs()
        {
            CreateMap<Name, Application.DTOs.Name>();
            CreateMap<Coordinates, Application.DTOs.Coordinates>();
            CreateMap<Timezone, Application.DTOs.Timezone>();
            CreateMap<Location, Application.DTOs.Location>();
            CreateMap<Street, Application.DTOs.Street>();
            CreateMap<Login, Application.DTOs.Login>();
            CreateMap<Dob, Application.DTOs.Dob>();
            CreateMap<Registered, Application.DTOs.Registered>();
            CreateMap<Id, Application.DTOs.Id>();
            CreateMap<Picture, Application.DTOs.Picture>();
            CreateMap<User, Application.DTOs.User>();
        }

        private void CreateMapDTOsToEntities()
        {
            CreateMap<Application.DTOs.Name, Name>()
                .ConstructUsing(s => new Name(s.Title, s.First, s.Last));
            CreateMap<Application.DTOs.Coordinates, Coordinates>()
                .ConstructUsing(s => new Coordinates(s.Latitude, s.Longitude));
            CreateMap<Application.DTOs.Timezone, Timezone>()
                .ConstructUsing(s => new Timezone(s.Offset, s.Description));
            CreateMap<Application.DTOs.Street, Street>()
                .ConstructUsing(s => new Street(s.Number, s.Name));
            CreateMap<Application.DTOs.Location, Location>()
                .ConstructUsing((s, r) =>
                {
                    Street street = r.Mapper.Map<Street>(s.Street);
                    Coordinates coordinates = r.Mapper.Map<Coordinates>(s.Coordinates);
                    Timezone timezone = r.Mapper.Map<Timezone>(s.Timezone);
                    return new Location(street, s.City, s.State, s.Postcode, coordinates, timezone);
                });
            CreateMap<Application.DTOs.Login, Login>()
                .ConstructUsing(s => new Login(s.Uuid, s.Username, s.Password, s.Salt, s.Md5, s.Sha1, s.Sha256));
            CreateMap<Application.DTOs.Dob, Dob>()
                .ConstructUsing(s => new Dob(s.Date, s.Age));
            CreateMap<Application.DTOs.Registered, Registered>()
                .ConstructUsing(s => new Registered(s.Date, s.Age));
            CreateMap<Application.DTOs.Id, Id>()
                .ConstructUsing(s => new Id(s.Name, s.Value));
            CreateMap<Application.DTOs.Picture, Picture>()
                .ConstructUsing(s => new Picture(s.Large, s.Medium, s.Thumbnail));
            CreateMap<Application.DTOs.User, User>()
                .ConstructUsing((s, r) =>
                {
                    Name name = r.Mapper.Map<Name>(s.Name);
                    Location location = r.Mapper.Map<Location>(s.Location);
                    Login login = r.Mapper.Map<Login>(s.Login);
                    Dob dob = r.Mapper.Map<Dob>(s.Dob);
                    Registered registered = r.Mapper.Map<Registered>(s.Registered);
                    Id id = r.Mapper.Map<Id>(s.Id);
                    Picture picture = r.Mapper.Map<Picture>(s.Picture);
                    return new User(s.Gender, name, location, s.Email, login, dob, registered, s.Phone, s.Cell, id, picture, s.Nat, Domain.Enums.EUserStatus.Draft);
                });
        }

        private void CreateMapEntitiesToViewModel()
        {
            CreateMap<User, UserViewModel>();
        }

        private void CreateMapViewModelToEntities()
        {
            CreateMap<PutUserRequest, User>()
                .ConstructUsing((s, r) =>
                {
                    Name name = r.Mapper.Map<Name>(s.Name);
                    Location location = r.Mapper.Map<Location>(s.Location);
                    Login login = r.Mapper.Map<Login>(s.Login);
                    Dob dob = r.Mapper.Map<Dob>(s.Dob);
                    Registered registered = r.Mapper.Map<Registered>(s.Registered);
                    Id id = r.Mapper.Map<Id>(s.Id);
                    Picture picture = r.Mapper.Map<Picture>(s.Picture);
                    return new User(s.Gender, name, location, s.Email, login, dob, registered, s.Phone, s.Cell, id, picture, s.Nat, Domain.Enums.EUserStatus.Draft);
                });
        }
    }
}
