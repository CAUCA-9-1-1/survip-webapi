using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class BuildingControllerOData : BaseODataController<BuildingService, Building>
	{
		private readonly WebuserService userService;
		private readonly CityService cityService; 

		public BuildingControllerOData(BuildingService service, WebuserService userService, CityService cityService): base(service)
		{
			this.cityService = cityService;
			this.userService = userService;
		}

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		[ODataRoute("Building"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<Building> GetList()
		{
			return Service.GetList(GetUserCityIds());
		}

	    [ODataRoute("BuildingChild"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
	    public IQueryable<Building> GetChildList()
	    {
	        return Service.GetChildListOData();
	    }

		[HttpPost]
		[ODataRoute("Building"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Post()
		{
			var json = JObject.Parse(ReadBody());
			var building = json.ToObject<Building>();

			if (building is null)
			{
				return BadRequest("cantAddBuilding");
			}

			Service.AddOrUpdate(building);
			return Ok();
		}


		[HttpPost]
		[ODataRoute("BuildingChild"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult PostChild()
		{
			var json = JObject.Parse(ReadBody());
			var building = json.ToObject<Building>();

			if (building is null)
			{
				return BadRequest("cantAddBuilding");
			}

			Service.AddOrUpdate(building);
			return Ok();
		}

		[HttpPatch]
		[ODataRoute("Building({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Patch([FromODataUri]Guid id)
		{
			var json = JObject.Parse(ReadBody());
			var entity = Service.PartialCopyTo(id, json);

			if (entity is null)
			{
				return NotFound();
			}
			
			Service.AddOrUpdate(entity);
			return Ok();
		}

		[HttpDelete]
		[ODataRoute("Building({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Delete([FromODataUri] Guid id)
		{
			if (Service.Remove(id))
			{
				return Ok();
			}

			return BadRequest("cantRemoveBuilding");
		}
	}
}