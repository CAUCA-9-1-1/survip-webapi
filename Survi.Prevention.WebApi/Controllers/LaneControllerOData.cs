using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class LaneControllerOData : ODataController
	{
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

		private readonly LaneService service;
		private readonly WebuserService userService;
		private readonly CityService cityService; 

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		public LaneControllerOData(LaneService service, WebuserService userService, CityService cityService)
		{
			this.service = service;
			this.cityService = cityService;
			this.userService = userService;
		}

		[ODataRoute("Lane"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<Lane> GetList()
		{
			return service.GetList(GetUserCityIds());
		}
		
		[HttpPost]
		[ODataRoute("Lane"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Post([FromBody]Lane lane)
		{
			if (lane is null)
			{
				return BadRequest("canAddLane");
			}

			service.AddOrUpdate(lane);
			return Ok();
		}
		
		[HttpPatch]
		[ODataRoute("Lane({id})"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IActionResult Patch([FromODataUri]Guid id, [FromBody]Delta<Lane> value)
		{
			var t = service.Get(id);
			if (t == null) return NotFound();
 
			value.Patch(t);
			service.AddOrUpdate(t);

			return Ok();
		}
	}
}