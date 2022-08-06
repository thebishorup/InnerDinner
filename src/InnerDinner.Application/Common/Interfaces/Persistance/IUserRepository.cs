using InnerDinner.Domain.Entities;

namespace InnerDinner.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}