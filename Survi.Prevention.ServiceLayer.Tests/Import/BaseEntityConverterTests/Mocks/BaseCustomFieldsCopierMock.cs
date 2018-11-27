using System;
using Survi.Prevention.ServiceLayer.Import.Base;
using BuildingAnomaly = Survi.Prevention.ApiClient.DataTransferObjects.BuildingAnomaly;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class BaseCustomFieldsCopierMock : BaseCustomFieldsCopier<BuildingAnomaly, Models.Buildings.BuildingAnomaly>
    {
        public bool CopyValuesIsCorrectlyCalled { get; set; }

        protected override void CopyValues(BuildingAnomaly importedObject, Models.Buildings.BuildingAnomaly entity)
        {
            CopyValuesIsCorrectlyCalled = true;
        }

        public new Guid? ParseId(string id)
        {
            return base.ParseId(id);
        }
    }
}