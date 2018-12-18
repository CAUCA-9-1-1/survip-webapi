using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation.Mocks
{
    public class FireHydrantImportationConverterMock : FireHydrantImportationConverter
    {
        public FireHydrantImportationConverterMock() : base(null, null, null)
        {
        }

        public void CopyCustomFields(FireHydrant imported, Models.FireHydrants.FireHydrant entity)
        {
            CopyCustomFieldsToEntity(imported, entity);
        }
    }
}