using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackEndChallengeDotNet.API.UseCases.Users.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("users")]
    [ApiController]
    public partial class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
            => _mediator = mediator;
    }
}
