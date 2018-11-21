using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/UtilisationCode")]
    public class UtilisationCodeController : BaseCrudControllerWithImportation<UtilisationCodeService, UtilisationCode, ApiClient.DataTransferObjects.UtilisationCode>
    {
        private readonly UtilisationCodeService service;

        public UtilisationCodeController(UtilisationCodeService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet, Route("localized")]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(List<UtilisationCodeForWeb>), 200)]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")]string languageCode)
        {
            return Ok(service.GetListLocalized(languageCode));
        }

        [HttpGet, Route("localized/{id:Guid}")]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(UtilisationCodeForWeb), 200)]
        public ActionResult GetUtilisationCodeForWeb([FromHeader(Name = "Language-Code")]string languageCode, Guid id)
        {
            var riskLevel = service.GetUtilisationCodeForWeb(id, languageCode);
            if (riskLevel == null)
                return NotFound();
            return Ok(riskLevel);
        }
    }
}