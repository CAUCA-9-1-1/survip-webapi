using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
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
	}
}