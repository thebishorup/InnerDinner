using InnerDinner.Application.Services.Authentication;
using InnerDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace InnerDinner.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class ApplicationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public ApplicationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var responseResult = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );

        return Ok(responseResult);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(
            request.Email,
            request.Password
        );

        var responseResult = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );

        return Ok(responseResult);
    }
}