using System.ComponentModel;

namespace BackEndChallengeDotNet.Application.Notifications
{
    public enum ErrorCode
    {
        [Description("Invalid parameters were inputed")]
        BadRequest = 400,

        [Description("Requested resource was not found")]
        NotFound = 404,

        [Description("Conflict processing request")]
        Conflict = 409,

        [Description("The request was well-formed but was unable to be followed.")]
        UnprocessableEntity = 422,
    }
}
