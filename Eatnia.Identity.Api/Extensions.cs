using Eatnia.Identity.Api.Entities;

namespace Eatnia.Identity.Api
{
    public static class Extensions
    {
        public static UserDto AsDto(this ApplicationUser user)
        {
            return new UserDto(
                user.Id,
                user.UserName,
                user.Email,
                user.Latitude,
                user.Longitude,
                user.Balance,
                user.CreatedOn);
        }
    }
}
