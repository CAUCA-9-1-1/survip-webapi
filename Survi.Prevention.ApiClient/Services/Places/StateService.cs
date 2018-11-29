using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Places
{
	public class StateService : BaseSecureService<State>
	{
		protected override string BaseUrl { get; set; } = "State/Import";

		public StateService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
