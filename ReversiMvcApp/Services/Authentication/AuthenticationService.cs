using Microsoft.AspNetCore.Http;
using ReversiMvcApp.Models;

namespace Reversi.Services.Authentication
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthenticationService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public Speler Get()
		{
			return (Speler)_httpContextAccessor.HttpContext.Items["speler"];
		}
	}
}
