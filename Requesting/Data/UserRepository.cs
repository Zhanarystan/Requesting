using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Requesting.Interfaces;
using Requesting.Models;
using System.Threading.Tasks;

namespace Requesting.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Client> _userManager;
        public UserRepository(IHttpContextAccessor httpContextAccessor, UserManager<Client> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Client> GetCurrentUser()
        {
            var contextUser = _httpContextAccessor.HttpContext?.User;
            if (!(contextUser.IsInRole("admin") || contextUser.IsInRole("user"))) return null;
            var user = await _userManager.FindByNameAsync(contextUser.Identity.Name);

            return user;
        }
    }
}
