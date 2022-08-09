using InnerDinner.Application.Authentication.Common;
using InnerDinner.Application.Common.Interfaces.Authentication;
using InnerDinner.Application.Common.Interfaces.Persistance;
using InnerDinner.Domain.Entities;
using MediatR;

namespace InnerDinner.Application.Authentication.Commands.Register.Handler;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //Check if user already exist with email
        if (_userRepository.GetUserByEmail(command.Email) is not null)
            throw new Exception($"User with email {command.Email} already exists.");

        //Create user
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        //Generate token
        var token = _tokenGenerator.GenerateToken(user);
        await Task.CompletedTask;

        return new AuthenticationResult
        (user,
         token);
    }
}