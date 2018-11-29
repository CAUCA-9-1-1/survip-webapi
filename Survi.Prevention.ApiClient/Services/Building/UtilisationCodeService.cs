using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class UtilisationCodeService : BaseSecureService<UtilisationCode>
	{
		protected override string BaseUrl { get; set; } = "UtilisationCode/Import";

		public UtilisationCodeService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
