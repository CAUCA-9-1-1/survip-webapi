using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation.Validators;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation.Mocks
{
    public class FireHydrantConnectionImportationConverterMock : FireHydrantConnectionImportationConverter
    {
        public FireHydrantConnectionImportationConverterMock() : base(null, new FireHydrantConnectionImportationValidator())
        {
        }

        public void CopyCustomFields(FireHydrantConnection connection, Models.FireHydrants.FireHydrantConnection entity)
        {
            CopyCustomFieldsToEntity(connection, entity);
        }
    }
}
