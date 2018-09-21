using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Survi.Prevention.Models.DataTransfertObjects;
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
		private readonly string minimalVersion;

		public AuthentificationController(AuthentificationService service, IConfiguration configuration)
		{
			this.service = service;
			issuer = configuration.GetSection("APIConfig:Issuer").Value;
			applicationName = configuration.GetSection("APIConfig:PackageName").Value;
			secretKey = configuration.GetSection("APIConfig:SecretKey").Value;
			minimalVersion = configuration.GetSection("APIConfig:MinimalVersion").Value;
		}

		[Route("[Action]"), HttpPost]
		public ActionResult Logon([FromBody]LoginInformations login)
		{
			var (token, user) = service.Login(login.Username, login.Password, applicationName, issuer, secretKey);
			if (user == null || token == null)
				return Unauthorized();

			return Ok(new
			{
				Data =
					new
					{
						AuthorizationType = "Token",
						token.ExpiresIn,
						AccessToken = token.TokenForAccess,
						token.RefreshToken,
						IdWebuser = user.Id,
						LastName = user.Attributes.Where(a => a.AttributeName=="last_name").Select(a => a.AttributeValue).FirstOrDefault() ?? "",
						FirstName = user.Attributes.Where(a => a.AttributeName == "first_name").Select(a => a.AttributeValue).FirstOrDefault() ?? "",
					}
			});
		}

		[Route("[Action]"), HttpPost, AllowAnonymous]
		public ActionResult Refresh([FromBody]TokenRefreshResult tokens)
		{
			try
			{
				var newAccessToken = service.Refresh(tokens.AccessToken, tokens.RefreshToken, applicationName, issuer, secretKey);
				return Ok(new { AccessToken = newAccessToken, tokens.RefreshToken });
			}
			catch (SecurityTokenExpiredException)
			{
				HttpContext.Response.Headers.Add("Refresh-Token-Expired", "true");
			}
			catch (SecurityTokenException)
			{
				HttpContext.Response.Headers.Add("Token-Invalid", "true");
			}

			return Unauthorized();
		}

		[HttpGet, Route("SessionStatus"), Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(401)]
		public ActionResult TokenIsStillValid()
		{
			return Ok(true);
		}

		[HttpGet, Route("VersionValidator/{mobileVersion:double}"), AllowAnonymous]
		[ProducesResponseType(200)]
		[ProducesResponseType(401)]
		public ActionResult MobileVersionIsValid(string mobileVersion)
		{
			return Ok(service.IsMobileVersionValid(mobileVersion, minimalVersion));
		}
	}
}