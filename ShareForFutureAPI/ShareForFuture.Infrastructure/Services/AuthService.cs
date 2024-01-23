using Microsoft.AspNetCore.Identity;
using ShareForFuture.Application.Models.Authentication;
using ShareForFuture.Domain.DomainModels;
using ShareForFuture.Infrastructure.Consts;
using ShareForFututre.Application.Contracts.Services;

namespace ShareForFuture.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(UserManager<User> userManager,
        ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _tokenHandler = tokenHandler;
    }
    
    public async Task<RegistrationResponseDto> RegisterAsync(RegistrationRequestDto registrationRequest)
    {
        var newUser = new User
        {
            FirstName = registrationRequest.FirstName,
            MiddleName = registrationRequest.MiddleName,
            LastName = registrationRequest.LastName,
            Email = registrationRequest.Email,
        };
        
        var result = await _userManager.CreateAsync(newUser, registrationRequest.Password);
        
        if (!result.Succeeded)
        {
            throw new Exception("User creation failed! Errors: " + string.Join(", ", result.Errors));
        }
        
        await _userManager.AddToRoleAsync(newUser, DbRolesConsts.UserRole);
        
        var response = new RegistrationResponseDto
        {
            Id = newUser.Id,
            FirstName = newUser.FirstName,
            Email = newUser.Email,
            Token = _tokenHandler.CreateAccessToken(newUser, new List<string> { DbRolesConsts.UserRole }),
        };
        
        return response;
    }
}

