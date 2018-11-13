
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Mocks
{
    public class MockRepository : BaseService<Country>
    {
        protected override string BaseUrl { get; set; } = "mock";
    }

    public class MockSecureRepository : BaseSecureService<Country>
    {
        protected override string BaseUrl { get; set; } = "mock";
    }
}
