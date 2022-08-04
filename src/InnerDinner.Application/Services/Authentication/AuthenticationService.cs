using InnerDinner.Application.Common.Interfaces;

namespace InnerDinner.Application.Services.Authentication;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult
        (
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exist with email

        //Create user

        //Generate token
        Guid userId = Guid.NewGuid();
        var token = _tokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult
        (
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token
        );
    }
}