using InnerDinner.Domain.Entities;

namespace InnerDinner.Application.Services.Authentication;

public record AuthenticationResult(User User, string Token);