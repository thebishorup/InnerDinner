namespace InnerDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string firstName, string LastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}