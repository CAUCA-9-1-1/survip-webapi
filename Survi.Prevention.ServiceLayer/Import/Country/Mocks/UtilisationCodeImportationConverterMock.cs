using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation;

namespace Survi.Prevention.ServiceLayer.Import.Country.Mocks
{
    public class UtilisationCodeImportationConverterMock : UtilisationCodeImportationConverter
    {
        public UtilisationCodeImportationConverterMock() : base(null, null)
        {
        }

        public void CopyCustomFields(UtilisationCode importedCode, Models.Buildings.UtilisationCode code)
        {
            CopyCustomFieldsToEntity(importedCode, code);
        }
    }
}
