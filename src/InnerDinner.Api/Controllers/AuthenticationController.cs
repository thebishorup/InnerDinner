using InnerDinner.Application.Authentication.Commands.Register;
using InnerDinner.Application.Authentication.Queries;
using InnerDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnerDinner.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class ApplicationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ApplicationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var authResult = await _mediator.Send(command);

        var responseResult = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(responseResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query);

        var responseResult = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(responseResult);
    }
}