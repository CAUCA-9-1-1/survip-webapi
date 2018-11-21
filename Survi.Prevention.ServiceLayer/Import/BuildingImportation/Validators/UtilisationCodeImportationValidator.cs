using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class UtilisationCodeImportationValidator : BaseImportValidator<ApiClient.DataTransferObjects.UtilisationCode>
    {
        public UtilisationCodeImportationValidator()
        {
            RuleFor(m => m.Cubf).NotNullOrEmptyWithMaxLength(5);
            RuleFor(m => m.Scian).NotNullOrEmptyWithMaxLength(10);
        }
    }
}