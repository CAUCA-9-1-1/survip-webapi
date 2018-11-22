using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using ImportConstructionType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionType;
using ImportFireResistanceType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionFireResistanceType;
using ImportSidingType = Survi.Prevention.ApiClient.DataTransferObjects.SidingType;
using ImportRoofType = Survi.Prevention.ApiClient.DataTransferObjects.RoofType;
using ImportRoofMaterialType = Survi.Prevention.ApiClient.DataTransferObjects.RoofMaterialType;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/construction")]
	public class ConstructionController : BaseSecuredController
	{
		private readonly ConstructionService service;

		public ConstructionController(ConstructionService service)
		{
			this.service = service;
		}

		[HttpGet, Route("SidingTypes")]
		public ActionResult GetBuildingSidingTypes([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetBuildingSidingTypes(languageCode));
		}

		[HttpGet, Route("BuildingTypes")]
		public ActionResult GetBuildingTypes([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetBuildingTypes(languageCode));
		}

		[HttpGet, Route("FireResistanceTypes")]
		public ActionResult GetConstructionFireResistanceTypes([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetConstructionFireResistanceTypes(languageCode));
		}

		[HttpGet, Route("ConstructionTypes")]
		public ActionResult GetConstructionTypes([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetConstructionTypes(languageCode));
		}

		[HttpGet, Route("RoofMaterialTypes")]
		public ActionResult GetRoofMaterialTypes([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetRoofMaterialTypes(languageCode));
		}

		[HttpGet, Route("RoofTypes")]
		public ActionResult GetRoofTypes([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.GetRoofTypes(languageCode));
		}

		[HttpGet, Route("All")]
		public ActionResult GetAllTypes([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetAllTypes(languageCode));
		}

	    [HttpPost, Route("ConstructionType/Import"), AllowAnonymous]
	    public ActionResult ImportConstructionTypes([FromBody] List<ImportConstructionType> importedEntities)
	    {
	        return Ok(service.Import<ConstructionType, ImportConstructionType>(importedEntities));
	    }

	    [HttpPost, Route("ConstructionFireResistanceType/Import"), AllowAnonymous]
	    public ActionResult ImportConstructionFireResistanceTypes([FromBody] List<ImportFireResistanceType> importedEntities)
	    {
	        return Ok(service.Import<ConstructionFireResistanceType, ImportFireResistanceType>(importedEntities));
	    }

	    [HttpPost, Route("SidingType/Import"), AllowAnonymous]
	    public ActionResult ImportSidingTypes([FromBody] List<ImportSidingType> importedEntities)
	    {
	        return Ok(service.Import<SidingType, ImportSidingType>(importedEntities));
        }

	    [HttpPost, Route("RoofType/Import"), AllowAnonymous]
	    public ActionResult ImportRoofTypes([FromBody] List<ImportRoofType> importedEntities)
	    {
	        return Ok(service.Import<RoofType, ImportRoofType>(importedEntities));
        }

	    [HttpPost, Route("RoofMaterialType/Import"), AllowAnonymous]
	    public ActionResult ImportRoofMaterialTypes([FromBody] List<ImportRoofMaterialType> importedEntities)
	    {
	        return Ok(service.Import<RoofMaterialType, ImportRoofMaterialType>(importedEntities));
        }
    }
}