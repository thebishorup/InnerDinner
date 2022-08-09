using InnerDinner.Domain.Entities;

namespace InnerDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);