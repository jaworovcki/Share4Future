using Microsoft.AspNetCore.Mvc;
using ShareForFuture.Application.Models.Authentication;
using ShareForFututre.Application.Contracts.Services;

namespace ShareForFuture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegistrationResponseDto))]
    public async Task<ActionResult<RegistrationResponseDto>> Register(RegistrationRequestDto request)
    {
        try
        {
            var response = await _authService.RegisterAsync(request);
            
            return CreatedAtAction(nameof(Register), response);
        }
        catch (Exception e)
        {
            return BadRequest("User registration failed! " + e.Message);
        }
    }
}