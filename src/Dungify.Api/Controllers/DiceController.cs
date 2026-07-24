using Dungify.Application.Abstractions;
using Dungify.Application.Commands;
using Dungify.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Dungify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DiceController : ControllerBase
{
    [HttpPost("roll")]
    [SwaggerOperation("Roll dice using a formula (e.g. '21d100', '37d10').")]
    [ProducesResponseType(typeof(DiceRollDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<DiceRollDto>> Post(
        [FromBody] DiceRoll command,
        [FromServices] ICommandHandler<DiceRoll, DiceRollDto> handler)
        => Ok(await handler.HandleAsync(command));
}