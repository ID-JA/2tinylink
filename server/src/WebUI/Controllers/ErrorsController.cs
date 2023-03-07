using Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var exceptionThrown = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if(exceptionThrown is AppException)
            {
                var appException = exceptionThrown as AppException;

                return Problem(statusCode: appException.StatusCode, title: appException.ErrorMessage);
            }

            
            return Problem();
        }
    }
}