using System.ComponentModel.DataAnnotations;

namespace AuthSample.Backend.Auth.Dto;

public class RefreshRequest
{
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}