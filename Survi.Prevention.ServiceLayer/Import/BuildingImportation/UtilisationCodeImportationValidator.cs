using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class UtilisationCodeImportationValidator : BaseImportValidator<ApiClient.DataTransferObjects.UtilisationCode>
    {
        public UtilisationCodeImportationValidator()
        {
            RuleFor(m => m.Cubf).NotNullOrEmpty();
            RuleFor(m => m.Scian).NotNullOrEmpty();
        }
    }
}