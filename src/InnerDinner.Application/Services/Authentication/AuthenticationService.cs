using InnerDinner.Application.Common.Interfaces.Authentication;
using InnerDinner.Application.Common.Interfaces.Persistance;
using InnerDinner.Domain.Entities;

namespace InnerDinner.Application.Services.Authentication;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        //Check if user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
            throw new Exception("User email or password is incorrect.");

        if (user.Password != password)
            throw new Exception("User email or password is incorrect.");

        //Generate JWT token
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        (
            user,
            token
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //Check if user already exist with email
        if (_userRepository.GetUserByEmail(email) is not null)
            throw new Exception($"User with email {email} already exists.");

        //Create user
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        //Generate token
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        (
            user,
            token
        );
    }
}