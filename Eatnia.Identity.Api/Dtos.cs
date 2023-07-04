using System.ComponentModel.DataAnnotations;

namespace Eatnia.Identity.Api
{
    public record UserDto(
        Guid Id,
        string Username,
        string Email,
        string Latitude,
        string Longitude,
        DateTimeOffset CreatedDate
    );

    public record UpdateUserDto(
        [Required][EmailAddress] string Email,
        [Required] string Latitude,
        [Required] string Longitude
    );
}