using BackEndChallengeDotNet.Application.Notifications;
using BackEndChallengeDotNet.Application.ReponseError;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackEndChallengeDotNet.API
{
    public abstract class BasePresenter
    {
        public virtual IActionResult GetActionResult<T>(T result, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
            where T : Result
        {
            if (result.IsInvalid())
                return CreateErrorResult(result);

            if (httpStatusCode == HttpStatusCode.NoContent)
                return new NoContentResult();

            return new OkResult();
        }

        protected virtual IActionResult CreateErrorResult<T>(T result)
            where T : Result
        {
            var errorBody = ApiError.FromResult(result);
            var httpCode = (HttpStatusCode)result.Error;

            return httpCode switch
            {
                HttpStatusCode.BadRequest => new BadRequestObjectResult(errorBody),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(errorBody),
                HttpStatusCode.NotFound => new NotFoundObjectResult(errorBody),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(errorBody),
                HttpStatusCode.Conflict => new ConflictObjectResult(errorBody),
                HttpStatusCode.Forbidden => new StatusCodeResult((int)HttpStatusCode.Forbidden),
                _ => new BadRequestObjectResult(errorBody),
            };
        }
    }
}
