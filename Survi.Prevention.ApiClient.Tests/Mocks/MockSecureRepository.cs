﻿using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Mocks
{
    public class MockSecureRepository : BaseSecureService<Country>
    {
        protected override string BaseUrl { get; set; } = "mock";

        public MockSecureRepository(IConfiguration configuration)
            : base(configuration)
        {
        }

        public new string GetAuthorizationHeaderValue() => base.GetAuthorizationHeaderValue();
    }
}