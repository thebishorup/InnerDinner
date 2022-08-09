using InnerDinner.Application.Authentication.Common;
using MediatR;

namespace InnerDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : IRequest<AuthenticationResult>;