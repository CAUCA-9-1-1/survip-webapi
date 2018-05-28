using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/FireSafetyDepartmentRiskLevel")]
	public class FireSafetyDepartmentRiskLevelController : BaseCrudController<FireSafetyDepartmentRiskLevelService, FireSafetyDepartmentRiskLevel>
	{
		public FireSafetyDepartmentRiskLevelController(FireSafetyDepartmentRiskLevelService service) : base(service)
		{
		}
	}
}