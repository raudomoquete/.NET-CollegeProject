using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace College.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        public ApiController(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;            
        }

        protected IActionResult Problem(List<string> errors)
        {
            if (errors == null || !errors.Any())
            {
                return BadRequest(new { Message = "An unknown error occurred." });
            }

            var problemDetails = new ValidationProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "One or more validation errors occurred.",
                Detail = "See the errors property for details.",
                Instance = HttpContext.Request.Path
            };

            foreach (var error in errors)
            {
                problemDetails.Errors.Add("Error", new[] { error });
            }

            _logger.LogError("Validation errors: {Errors}", string.Join(", ", errors));

            return BadRequest(problemDetails);
        }
    }
}
