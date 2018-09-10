using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/RiskLevel")]
	public class RiskLevelController : BaseCrudController<RiskLevelService, RiskLevel>
    {
		private readonly RiskLevelService service;

		public RiskLevelController(RiskLevelService service) : base(service)
		{
			this.service = service;
		}

		[HttpGet, Route("localized/{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(404)]
		[ProducesResponseType(typeof(RiskLevelForWeb), 200)]
		public ActionResult GetRiskLevelForWeb([FromHeader(Name = "Language-Code")]string languageCode, Guid id)
		{
			var riskLevel = service.GetRiskLevelForWeb(id, languageCode);
			if (riskLevel == null)
				return NotFound();
			return Ok(riskLevel);
		}

		[HttpGet, Route("localized")]
        [ProducesResponseType(401)]
		[ProducesResponseType(typeof(List<RiskLevelForWeb>), 200)]
		public ActionResult GetRiskLevelsForWeb([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetRiskLevelsForWeb(languageCode));
		}
	}
}