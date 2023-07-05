using Duende.IdentityServer.Models;

namespace Eatnia.Identity.Api.Settings
{
    public class IdentitySettings
    {
        public string AdminUserEmail { get; init; }
        public string AdminUserPassword { get; init; }
        public decimal StartingBalance { get; set; }
    }
}