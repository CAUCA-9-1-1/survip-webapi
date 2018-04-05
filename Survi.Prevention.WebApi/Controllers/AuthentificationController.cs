using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class AuthentificationController : Controller
	{
		private readonly AuthentificationService service;

		public AuthentificationController([FromServices] AuthentificationService service, IConfiguration configuration)
		{
			this.service = service;
		}

		[Route("[Action]"), HttpPost]
		public ActionResult Logon(string user, string password)
		{
			var result = service.Login(user, password);
			if (result.user == null || result.token == null)
				return Unauthorized();

			return Ok(new
			{
				Data =
					new
					{
						AuthorizationType = "Token",
						result.token.ExpiresIn,
						AccessToken = result.token.TokenForAccess,
						result.token.RefreshToken,
						IdWebuser = result.user.Id
					}
			});
		}
	}
}