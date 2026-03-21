using System.ComponentModel.DataAnnotations;

namespace AuthSample.Backend.Services;

public class RegisterRequest
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Login { get; set; } = string.Empty;
    
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}