using Microsoft.AspNetCore.Mvc;
using TeamOn.Domain.Contracts.Commands;
using TeamOn.Domain.Humor.Commands.Handlers;
using TeamOn.Domain.Humor.Commands.Inputs;
using TeamOn.Domain.Humor.Entities;

namespace TeamOn.Domain.Api.Controllers;

[ApiController]
[Route("/humor")]
public class WeatherForecastController : ControllerBase
{
    [Route("send")]
    [HttpPost]
    public ICommandResult SendHumor(
        [FromBody] SendHumorCommand command,
        [FromServices] SendHumorHandler handler)
    => handler.Handle(command);

    [Route("all/user")]
    [HttpGet]
    public IEnumerable<HumorEntity> GetAllHumorsByUser(
        [FromBody] string refUser,
        [FromServices] GetHumorHandler handler)
        => handler.GetAllByUser(refUser);

    [Route("id")]
    [HttpGet]
    public List<HumorEntity> GetAllHumorsById([FromBody] string humorId)
        => throw new NotImplementedException();
}
