using BackEndChallengeDotNet.API.UseCases.Users.V1.Put;
using BackEndChallengeDotNet.Application.ReponseError;
using BackEndChallengeDotNet.Application.UseCases.Users.V1.Put;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.API.UseCases.Users.V1
{
    public partial class UsersController
    {
        [HttpPut("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put([FromServices] PutUserPresenter presenter, [FromRoute] string userId, [FromBody] PutUserRequest request)
        {
            var result = await _mediator.Send(new PutUserCommand(userId, request));

            return presenter.GetActionResult(result, HttpStatusCode.NoContent);
        }
    }
}
