using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
	public class BuildingControllerOData : ODataController
	{
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

		private readonly BuildingService service;
		private readonly WebuserService userService;
		private readonly CityService cityService; 

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		public BuildingControllerOData(BuildingService service, WebuserService userService, CityService cityService)
		{
			this.service = service;
			this.cityService = cityService;
			this.userService = userService;
		}

		[ODataRoute("Building"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<Building> GetList()
		{
			return service.GetList(GetUserCityIds());
		}
		
		[HttpPost]
		[ODataRoute("Building"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Post()
		{
			string body = new StreamReader(Request.Body).ReadToEnd();
			var json = JObject.Parse(body);
			var building = json.ToObject<Building>();

			if (building is null)
			{
				return BadRequest("cantAddBuilding");
			}

			service.AddOrUpdate(building);
			return Ok();
		}

		[HttpPatch]
		[ODataRoute("Building({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Patch([FromODataUri]Guid id)
		{
			var body = new StreamReader(Request.Body).ReadToEnd();
			var json = JObject.Parse(body);
			var building = json.ToObject<Building>();
			var entity = service.Get(id);

			if (entity == null)
			{
				return NotFound();
			}

			foreach (var item in json)
			{
				var propertyName = item.Key.First().ToString().ToUpper() + String.Join("", item.Key.Skip(1));
				var propertyValue = building.GetType().GetProperty(propertyName).GetValue(building, null);

				entity.GetType().GetProperty(propertyName).SetValue(entity, propertyValue, null);
			}
			
			service.AddOrUpdate(entity);
			return Ok();
		}

		[HttpDelete]
		[ODataRoute("Building({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Delete([FromODataUri] Guid id)
		{
			if (service.Remove(id))
			{
				return Ok();
			}

			return BadRequest("cantRemoveBuilding");
		}
	}
}