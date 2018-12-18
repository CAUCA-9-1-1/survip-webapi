using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.FireHydrantImportation;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireHydrantImportation.Mocks
{
    public class UnitOfMeasureImportationConverterMock : UnitOfMeasureImportationConverter
    {
        public UnitOfMeasureImportationConverterMock() : base(null, null, null)
        {
        }

        public void CopyCustomFields(UnitOfMeasure imported, Models.UnitOfMeasure entity)
        {
            CopyCustomFieldsToEntity(imported, entity);
        }
    }
}