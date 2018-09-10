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
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class FireHydrantControllerOData : ODataController
	{
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

		private readonly FireHydrantService service;
		private readonly WebuserService userService;
		private readonly CityService cityService; 

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		public FireHydrantControllerOData(FireHydrantService service, WebuserService userService, CityService cityService)
		{
			this.service = service;
			this.cityService = cityService;
			this.userService = userService;
		}

		[ODataRoute("FireHydrant"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<FireHydrant> GetList()
		{
			return service.GetList(GetUserCityIds());
		}
		
		[HttpPost]
		[ODataRoute("FireHydrant"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Post()
		{
			string body = new StreamReader(Request.Body).ReadToEnd();
			var json = JObject.Parse(body);
			var fireHydrant = json.ToObject<FireHydrant>();

			if (fireHydrant is null)
			{
				return BadRequest("cantAddFireHydrant");
			}

			service.AddOrUpdate(fireHydrant);
			return Ok();
		}

		[HttpPatch]
		[ODataRoute("FireHydrant({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Patch([FromODataUri]Guid id)
		{
			var body = new StreamReader(Request.Body).ReadToEnd();
			var json = JObject.Parse(body);
			var fireHydrant = json.ToObject<FireHydrant>();
			var entity = service.Get(id);

			if (entity == null)
			{
				return NotFound();
			}

			foreach (var item in json)
			{
				var propertyName = item.Key.First().ToString().ToUpper() + String.Join("", item.Key.Skip(1));
				var propertyValue = fireHydrant.GetType().GetProperty(propertyName).GetValue(fireHydrant, null);

				entity.GetType().GetProperty(propertyName).SetValue(entity, propertyValue, null);
			}
			
			service.AddOrUpdate(entity);
			return Ok();
		}

		[HttpDelete]
		[ODataRoute("FireHydrant({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Delete([FromODataUri] Guid id)
		{
			if (service.Remove(id))
			{
				return Ok();
			}

			return BadRequest("cantRemoveFireHydrant");
		}
	}
}