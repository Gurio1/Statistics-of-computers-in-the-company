using API_46731r.Domain.Exceptions;
using API_46731r.Domain.Exceptions.Authentication;
using API_46731r.ErrorResponses;
using API_46731r.ErrorResponses.Abstractions;
using API_46731r.ErrorResponses.Authetication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API_46731r.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public IErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Exception
            Response.StatusCode = 500; // Internal Server Error by default

            if (exception is InvalidPasswordExeption invalidPasswordExeption)
            {
                Response.StatusCode = 400;

                return new InvalidLogInDataError(invalidPasswordExeption);
            }
            else if(exception is InvalidEmailExeption invalidEmailExeption)
            {
                Response.StatusCode = 400;

                return new InvalidLogInDataError(invalidEmailExeption);
            }

            return new ErrorResponse(exception);
        }
    }
}
