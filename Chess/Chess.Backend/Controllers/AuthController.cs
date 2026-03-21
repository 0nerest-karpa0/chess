
using AuthSample.Backend.Auth.Dto;
using AuthSample.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourApp.Services;

namespace AuthSample.Backend.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _authService.RegisterAsync(request);
        
        if (!result.Success)
        {
            return BadRequest(new { message = result.ErrorMessage });
        }
        
        return Ok(result.Response);
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _authService.LoginAsync(request);
        
        if (!result.Success)
        {
            return BadRequest(new { message = result.ErrorMessage });
        }
        
        return Ok(result.Response);
    }
    
    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _authService.RefreshTokenAsync(request);
        
        if (!result.Success)
        {
            return BadRequest(new { message = result.ErrorMessage });
        }
        
        return Ok(result.Response);
    }
    
    [HttpPost("logout")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _authService.LogoutAsync(request);
        
        if (!result.Success)
        {
            return BadRequest(new { message = result.ErrorMessage });
        }
        
        return Ok(new { message = "Выход выполнен успешно" });
    }
}