using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class FireHydrantControllerOData : BaseODataController<FireHydrantService, FireHydrant>
	{
		private readonly WebuserService userService;
		private readonly CityService cityService; 

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		public FireHydrantControllerOData(FireHydrantService service, WebuserService userService, CityService cityService): base(service)
		{
			this.cityService = cityService;
			this.userService = userService;
		}

		[ODataRoute("FireHydrant"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<FireHydrant> GetList()
		{
			return Service.GetList(GetUserCityIds());
		}
		
		[HttpPost]
		[ODataRoute("FireHydrant"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Post()
		{
			var json = JObject.Parse(ReadBody());
			var fireHydrant = json.ToObject<FireHydrant>();

			if (fireHydrant is null)
			{
				return BadRequest("cantAddFireHydrant");
			}

			Service.AddOrUpdate(fireHydrant, CurrentUserId);
			return Ok();
		}

		[HttpPatch]
		[ODataRoute("FireHydrant({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Patch([FromODataUri]Guid id)
		{
			var json = JObject.Parse(ReadBody());
			var entity = Service.PartialCopyTo(id, json);

			if (entity is null)
			{
				return NotFound();
			}
			
			Service.AddOrUpdate(entity, CurrentUserId);
			return Ok();
		}

		[HttpDelete]
		[ODataRoute("FireHydrant({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Delete([FromODataUri] Guid id)
		{
			if (Service.Remove(id, CurrentUserId))
			{
				return Ok();
			}

			return BadRequest("cantRemoveFireHydrant");
		}
	}
}