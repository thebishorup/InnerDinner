using InnerDinner.Application.Common.Interfaces.Persistance;
using InnerDinner.Domain.Entities;

namespace InnerDinner.Infrastructure.Persistance;

public sealed class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
        => _users.SingleOrDefault(u => u.Email == email);
}