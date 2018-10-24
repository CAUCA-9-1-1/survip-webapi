using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class LaneControllerOData : BaseODataController<LaneService, Lane>
	{
		private readonly WebuserService userService;
		private readonly CityService cityService; 

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		public LaneControllerOData(LaneService service, WebuserService userService, CityService cityService): base(service)
		{
			this.cityService = cityService;
			this.userService = userService;
		}

		[ODataRoute("Lane"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<Lane> GetList()
		{
			return Service.GetList(GetUserCityIds());
		}
		
		[HttpPost]
		[ODataRoute("Lane"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Post([FromBody]Lane lane)
		{
			if (lane is null)
			{
				return BadRequest("cantAddLane");
			}

			Service.AddOrUpdate(lane, CurrentUserId);
			return Ok();
		}
		
		[HttpPatch]
		[ODataRoute("Lane({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
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
		[ODataRoute("Lane({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Delete([FromODataUri] Guid id)
		{
			if (Service.Remove(id, CurrentUserId))
			{
				return Ok();
			}

			return BadRequest("cantRemoveLane");
		}
	}
}