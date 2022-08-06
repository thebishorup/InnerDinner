using InnerDinner.Domain.Entities;

namespace InnerDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}