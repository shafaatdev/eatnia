using System.ComponentModel.DataAnnotations;

namespace Eatnia.Identity.Api
{
    public record UserDto(
        Guid Id,
        string Username,
        string Email,
        string Latitude,
        string Longitude,
        decimal Balance,
        DateTimeOffset CreatedDate
    );

    public record UpdateUserDto(
        [Required][EmailAddress] string Email,
        [Required] string Latitude,
        [Required] string Longitude,
        [Range(0, 100000)] decimal Balance
    );
}