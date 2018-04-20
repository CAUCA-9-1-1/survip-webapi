using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/UtilisationCode")]
	public class UtilisationCodeController : BaseSecuredController
	{
		private readonly UtilisationCodeService service;

		public UtilisationCodeController(UtilisationCodeService service)
		{
			this.service = service;
		}

		[HttpGet]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		[ProducesResponseType(typeof(RiskLevelForWeb), 200)]
		public ActionResult GetCodeForWeb([FromHeader]string languageCode, Guid id)
		{
			var riskLevel = service.GetForWeb(id, languageCode);
			if (riskLevel == null)
				return NotFound();
			return Ok(riskLevel);
		}
	}
}