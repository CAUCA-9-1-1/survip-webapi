using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class HazardousMaterialImportationValidator : BaseImportValidator<ApiClient.DataTransferObjects.HazardousMaterial>
    {
        public HazardousMaterialImportationValidator()
        {
            RuleFor(m => m.GuideNumber).NotNullOrEmpty();
            RuleFor(m => m.Number).NotNullOrEmpty();
        }
    }
}