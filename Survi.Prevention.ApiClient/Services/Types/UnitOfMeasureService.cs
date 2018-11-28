using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class UnitOfMeasureService : BaseSecureService<UnitOfMeasure>
	{
		protected override string BaseUrl { get; set; } = "UnitOfMeasure/Import";
	}    
}