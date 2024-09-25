using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCSMock.API.Core;

namespace SCSMock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if (result.IsSuccess && result.Value != null) // Found
                return Ok(result.Value);
            if (result.IsSuccess && result.Value == null) // Not Found
                return NotFound();
            return BadRequest(result.Error);

        }
    }
}
