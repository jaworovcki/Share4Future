using ShareForFuture.Application.Models.Authentication;

namespace ShareForFututre.Application.Contracts.Services;

public interface IAuthService
{
    Task<RegistrationResponseDto> RegisterAsync(RegistrationRequestDto registrationRequest);
}

