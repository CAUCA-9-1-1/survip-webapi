using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class BuildingForDashboardController : ODataController
	{
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

		private readonly InspectionService service;

		public BuildingForDashboardController(InspectionService service)
		{
			this.service = service;
		}

		[ODataRoute("BuildingsWithoutInspection"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All), AllowAnonymous]
		public IQueryable<BuildingWithoutInspection> GetBuildingWithoutInspection([FromHeader]string languageCode)
		{
			return service.GetBuildingWithoutInspectionQueryable(languageCode);
		}

		[ODataRoute("InspectionsToDo"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All), AllowAnonymous]
		public IQueryable<InspectionToDo> GetInspectionsToDo([FromHeader]string languageCode)
		{
			return service.GetToDoInspections(languageCode);
		}

		[ODataRoute("InspectionsForApproval"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All), AllowAnonymous]
		public IQueryable<InspectionForApproval> GetInspectionsForApproval([FromHeader]string languageCode)
		{
			return service.GetInspectionsForApproval(languageCode);
		}

		[ODataRoute("InspectionsCompleted"), EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All), AllowAnonymous]
		public IQueryable<InspectionCompleted> GetInspectionsCompleted([FromHeader]string languageCode)
		{
			return service.GetInspectionsCompleted(languageCode);
		}
	}
}