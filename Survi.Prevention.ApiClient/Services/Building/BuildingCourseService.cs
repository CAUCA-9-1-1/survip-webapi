using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingCourseService : BaseSecureService<BuildingCourse>
	{
		protected override string BaseUrl { get; set; } = "building/Course/Import";

		public BuildingCourseService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}