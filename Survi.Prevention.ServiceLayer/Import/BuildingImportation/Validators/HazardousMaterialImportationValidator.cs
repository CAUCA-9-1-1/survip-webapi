using FluentValidation;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class HazardousMaterialImportationValidator : BaseImportValidator<ApiClient.DataTransferObjects.HazardousMaterial>
    {
        public HazardousMaterialImportationValidator()
        {
            RuleFor(m => m.GuideNumber).NotNullOrEmptyWithMaxLength(255);
            RuleFor(m => m.Number).NotNullOrEmptyWithMaxLength(25);
        }
    }
}