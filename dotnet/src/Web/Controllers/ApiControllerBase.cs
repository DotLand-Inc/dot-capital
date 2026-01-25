using Cortex.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Dotland.DotCapital.WebApi.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}
