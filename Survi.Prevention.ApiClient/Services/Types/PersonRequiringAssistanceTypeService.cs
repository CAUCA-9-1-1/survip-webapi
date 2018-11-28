using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class PersonRequiringAssistanceTypeService : BaseSecureService<PersonRequiringAssistanceType>
	{
		protected override string BaseUrl { get; set; } = "PersonRequiringAssistanceType/Import";
	}    
}
