using InnerDinner.Application.Authentication.Commands.Register;
using InnerDinner.Application.Authentication.Common;
using InnerDinner.Application.Authentication.Queries;
using InnerDinner.Contracts.Authentication;
using Mapster;

namespace InnerDinner.Api.Common.Mappings;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}