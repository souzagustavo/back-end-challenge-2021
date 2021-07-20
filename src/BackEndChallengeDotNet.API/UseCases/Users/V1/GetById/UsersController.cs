using BackEndChallengeDotNet.API.UseCases.Users.V1.GetById;
using BackEndChallengeDotNet.Application.ReponseError;
using BackEndChallengeDotNet.Application.UseCases.Users.V1.GetById;
using BackEndChallengeDotNet.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.API.UseCases.Users.V1
{
    public partial class UsersController
    {
        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([FromServices] GetByIdUserPresenter presenter, [FromRoute] string userId)
        {
            var result = await _mediator.Send(new GetByIdUserCommand(userId));

            return presenter.GetActionResult(result);
        }
    }
}
