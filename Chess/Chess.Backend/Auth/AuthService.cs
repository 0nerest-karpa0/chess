
using Chess.Backend;
using AuthSample.Backend.Auth.Dto;
using AuthSample.Backend.Entity;
using AuthSample.Backend.JWT;
using AuthSample.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace YourApp.Services;

public interface IAuthService
{
    Task<(bool Success, AuthResponse? Response, string ErrorMessage)> 
        RegisterAsync(RegisterRequest request);
    
    Task<(bool Success, AuthResponse? Response, string ErrorMessage)> 
        LoginAsync(LoginRequest request);
    
    Task<(bool Success, AuthResponse? Response, string ErrorMessage)> 
        RefreshTokenAsync(RefreshRequest request);
    
    Task<(bool Success, string ErrorMessage)> 
        LogoutAsync(LogoutRequest request);
}

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;
    //private readonly IPasswordValidator<> _passwordValidator;
    private readonly JwtSettings _jwtSettings;
    
    public AuthService(
        ApplicationDbContext context,
        IJwtService jwtService,
        //IPasswordValidator passwordValidator,
        IOptions<JwtSettings> jwtSettings
    )
    {
        _context = context;
        _jwtService = jwtService;
        //_passwordValidator = passwordValidator;
        _jwtSettings = jwtSettings.Value;
    }
    
    public async Task<(bool Success, AuthResponse? Response, string ErrorMessage)>
        RegisterAsync(RegisterRequest request)
    {
        // Валидация пароля
        /*var validationResult = _passwordValidator.Validate(request.Password);
        if (!validationResult.IsValid)
        {
            return (false, null, validationResult.ErrorMessage);
        }*/
        
        // Проверка существования пользователя
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Login == request.Login);
        
        if (existingUser != null)
        {
            return (false, null, "Пользователь с таким логином уже существует");
        }
        
        // Создание пользователя
        var user = new User
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
        };
        
        _context.Users.Add(user);
        
        // Создание refresh токена
        var refreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = _jwtService.GenerateRefreshToken(),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(
                _jwtSettings.RefreshTokenExpirationDays
            ),
            IsRevoked = false
        };
        
        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();
        
        // Генерация access токена
        var accessToken = _jwtService.GenerateAccessToken(
            user.Id,
            user.Login
        );
        
        var response = new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
            UserId = user.Id
        };
        
        return (true, response, string.Empty);
    }
    
    public async Task<(bool Success, AuthResponse? Response, string ErrorMessage)>
        LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Login == request.Login);
        
        if (user == null)
        {
            return (false, null, "Неверный логин или пароль");
        }
        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return (false, null, "Неверный логин или пароль");
        }
        
        // Создание refresh токена
        var refreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = _jwtService.GenerateRefreshToken(),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(
                _jwtSettings.RefreshTokenExpirationDays
            ),
            IsRevoked = false
        };
        
        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();
        
        // Генерация access токена
        var accessToken = _jwtService.GenerateAccessToken(
            user.Id,
            user.Login
        );
        
        var response = new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
            UserId = user.Id
        };
        
        return (true, response, string.Empty);
    }
    
    public async Task<(bool Success, AuthResponse? Response, string ErrorMessage)>
        RefreshTokenAsync(RefreshRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId);
        
        if (user == null)
        {
            return (false, null, "Пользователь не найден");
        }
        
        var storedToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(
                rt => rt.UserId == request.UserId &&
                rt.Token == request.RefreshToken
            );
        
        if (storedToken == null)
        {
            return (false, null, "Неверный refresh токен");
        }
        
        if (!storedToken.IsActive)
        {
            return (false, null, "Refresh токен истек или был отозван");
        }
        
        // Отзыв старого токена
        storedToken.IsRevoked = true;
        
        // Создание нового refresh токена
        var newRefreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = _jwtService.GenerateRefreshToken(),
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddDays(
                _jwtSettings.RefreshTokenExpirationDays
            ),
            IsRevoked = false
        };
        
        _context.RefreshTokens.Add(newRefreshToken);
        await _context.SaveChangesAsync();
        
        // Генерация нового access токена
        var accessToken = _jwtService.GenerateAccessToken(
            user.Id,
            user.Login
        );
        
        var response = new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token,
            UserId = user.Id,
        };
        
        return (true, response, string.Empty);
    }
    
    public async Task<(bool Success, string ErrorMessage)> 
        LogoutAsync(LogoutRequest request)
    {
        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(
                rt => rt.UserId == request.UserId &&
                rt.Token == request.RefreshToken
            );
        
        if (token == null)
        {
            return (false, "Refresh токен не найден");
        }
        
        _context.RefreshTokens.Remove(token);
        await _context.SaveChangesAsync();
        
        return (true, string.Empty);
    }
}