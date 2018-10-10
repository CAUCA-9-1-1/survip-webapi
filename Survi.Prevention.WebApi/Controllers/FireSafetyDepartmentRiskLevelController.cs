using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/FireSafetyDepartmentRiskLevel")]
	public class FireSafetyDepartmentRiskLevelController : BaseSecuredController
	{
		protected FireSafetyDepartmentInspectionConfigurationService Service;

		public FireSafetyDepartmentRiskLevelController(FireSafetyDepartmentInspectionConfigurationService service) 
		{
			Service = service;
		}

		[HttpGet]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Get(Guid id)
		{
			var entity = Service.Get(id);
			return Ok(entity);
		}

		[HttpGet]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Get()
		{
			var result = Service.GetList();

			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(401)]
		[ProducesResponseType(200, Type = typeof(Guid))]
		[Route("{id:Guid}/UsedRiskLevels/{idFireSafetyDepartment:Guid}")]
		public ActionResult<Guid> GetUsedFireSafetyDepartment(Guid id, Guid idFireSafetyDepartment) 
			=> Ok(Service.GetUsedRiskLevelForFireSafetyDepartmentConfiguration(id, idFireSafetyDepartment));

		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] FireSafetyDepartmentInspectionConfigurationForEdition entity)
		{
			if (Service.AddOrUpdate(entity) != Guid.Empty)
				return Ok(new { id = entity.Id });

			return BadRequest();
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Delete(Guid id)
		{
			if (Service.Remove(id))
				return NoContent();

			return BadRequest();
		}
	}
}