using BackEndChallengeDotNet.API.UseCases.Users.V1.Delete;
using BackEndChallengeDotNet.Application.ReponseError;
using BackEndChallengeDotNet.Application.UseCases.Users.V1.Delete;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.API.UseCases.Users.V1
{
    public partial class UsersController
    {
        [HttpDelete("{userId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromServices] DeleteUserPresenter presenter, [FromRoute] string userId)
        {        
            var result = await _mediator.Send(new DeleteUserCommand(userId));

            return presenter.GetActionResult(result);
        }
    }
}
