using Cause.SecurityManagement.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class AuthentificationController : AuthentifiedController
	{
		private readonly AuthenticationService service;
		private readonly string issuer;
		private readonly string applicationName;
		private readonly string secretKey;
		private readonly string minimalVersion;

		public AuthentificationController(AuthenticationService service, IConfiguration configuration)
		{
			this.service = service;
			issuer = configuration.GetSection("APIConfig:Issuer").Value;
			applicationName = configuration.GetSection("APIConfig:PackageName").Value;
			secretKey = configuration.GetSection("APIConfig:SecretKey").Value;
			minimalVersion = configuration.GetSection("APIConfig:MinimalVersion").Value;
		}

		[HttpGet, Route("SessionStatus"), Authorize]
		[ProducesResponseType(200)]
		[ProducesResponseType(401)]
		public ActionResult TokenIsStillValid()
		{
			return Ok(true);
		}

		[HttpGet, Route("VersionValidator/{mobileVersion}"), AllowAnonymous]
		[ProducesResponseType(200)]
		[ProducesResponseType(401)]
		public ActionResult MobileVersionIsValid(string mobileVersion)
		{
			return Ok(service.IsMobileVersionValid(mobileVersion, minimalVersion));
		}
	}
}