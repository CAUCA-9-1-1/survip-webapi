using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class AuthentificationController : Controller
	{
		private readonly AuthentificationService service;
		private readonly string issuer;
		private readonly string applicationName;
		private readonly string secretKey;

		public AuthentificationController(AuthentificationService service, IConfiguration configuration)
		{
			this.service = service;
			issuer = configuration.GetSection("APIConfig:Issuer").Value;
			applicationName = configuration.GetSection("APIConfig:PackageName").Value;
			secretKey = configuration.GetSection("APIConfig:SecretKey").Value;
		}

		[Route("[Action]"), HttpPost]
		public ActionResult Logon(string user, string password)
		{
			var result = service.Login(user, password, applicationName, issuer, secretKey);
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

		[HttpGet, Route("SessionStatus"), Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(401)]
		public ActionResult TokenIsStillValid()
		{
			return Ok();
		}
	}
}