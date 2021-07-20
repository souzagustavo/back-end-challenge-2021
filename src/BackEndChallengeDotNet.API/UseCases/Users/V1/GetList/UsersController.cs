using BackEndChallengeDotNet.API.UseCases.Users.V1.GetList;
using BackEndChallengeDotNet.Application.UseCases.Users.V1.GetList;
using BackEndChallengeDotNet.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.API.UseCases.Users.V1
{
    public partial class UsersController
    {
        [HttpGet]
        [ProducesResponseType(typeof(UserViewModel[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromServices] GetListUserPresenter presenter, [FromHeader(Name = "X-page-number")] int pageNumber, [FromHeader(Name = "X-page-size")] int pageSize)
        {
            var result = await _mediator.Send(new GetListUserCommand(pageNumber, pageSize));

            return presenter.GetActionResult(result);
        }
    }
}
