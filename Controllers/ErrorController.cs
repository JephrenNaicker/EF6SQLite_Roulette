using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF6SQLite_Roulette.Controllers
{
    //handles Errors
    [ApiController]

    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? context = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;


            //Log error

            return Problem(title:context?.Message,statusCode:400);

        }
    }
}
