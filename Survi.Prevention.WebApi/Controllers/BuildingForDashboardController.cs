using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class BuildingForDashboardController : ODataController
	{
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

		private readonly InspectionService service;
		private readonly UserService userService;
		private readonly CityService cityService; 

		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		public BuildingForDashboardController(InspectionService service, UserService userService, CityService cityService)
		{
			this.service = service;
			this.cityService = cityService;
			this.userService = userService;
		}

		[ODataRoute("BuildingsWithoutInspection"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<BuildingWithoutInspection> GetBuildingWithoutInspection([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return service.GetBuildingWithoutInspectionQueryable(languageCode, GetUserCityIds());
		}

		[ODataRoute("InspectionsToDo"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<InspectionToDo> GetInspectionsToDo([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return service.GetToDoInspections(languageCode, GetUserCityIds());
		}

		[ODataRoute("InspectionsForApproval"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<InspectionForApproval> GetInspectionsForApproval([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return service.GetInspectionsForApproval(languageCode, GetUserCityIds());
		}

		[ODataRoute("InspectionsCompleted"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
		public IQueryable<InspectionCompleted> GetInspectionsCompleted([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return service.GetInspectionsCompleted(languageCode, GetUserCityIds());
		}
	}
}