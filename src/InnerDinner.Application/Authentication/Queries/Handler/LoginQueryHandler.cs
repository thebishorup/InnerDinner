using InnerDinner.Application.Authentication.Common;
using InnerDinner.Application.Common.Interfaces.Authentication;
using InnerDinner.Application.Common.Interfaces.Persistance;
using InnerDinner.Domain.Entities;
using MediatR;

namespace InnerDinner.Application.Authentication.Queries.Handler;

public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        //Check if user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
            throw new Exception("User email or password is incorrect.");

        if (user.Password != query.Password)
            throw new Exception("User email or password is incorrect.");

        //Generate JWT token
        var token = _tokenGenerator.GenerateToken(user);

        await Task.CompletedTask;

        return new AuthenticationResult
        (
            user,
            token
        );
    }
}