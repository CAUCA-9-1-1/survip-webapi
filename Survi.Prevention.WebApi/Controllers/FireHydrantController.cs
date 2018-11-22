using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/FireHydrant")]
    public class FireHydrantController 
        : BaseCrudControllerWithImportation<FireHydrantService, FireHydrant, ApiClient.DataTransferObjects.FireHydrant>
    {
        private readonly FireHydrantConnectionService connectionService;

	    public FireHydrantController(FireHydrantService service, FireHydrantConnectionService connectionService) 
	        : base(service)
	    {
	        this.connectionService = connectionService;
	    }

		[HttpGet, Route("city/{idCity:Guid}")]
		public ActionResult GetListLocalized(Guid idCity, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetListForCity(idCity, languageCode));
		}

		[HttpGet, Route("city/{idCity:Guid}/building/{idBuilding:Guid}")]
		public ActionResult GetCityListLocalizedForBuilding(Guid idCity, Guid idBuilding, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetCityListForBuilding(idCity, idBuilding, languageCode));
		}

        [HttpPost, Route("connection/import"), AllowAnonymous]
        public ActionResult Import([FromBody] List<ApiClient.DataTransferObjects.FireHydrantConnection> importedEntities)
        {
            return Ok(connectionService.Import(importedEntities));
        }
    }
}
