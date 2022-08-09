using InnerDinner.Application.Authentication.Common;
using MediatR;

namespace InnerDinner.Application.Authentication.Queries;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;