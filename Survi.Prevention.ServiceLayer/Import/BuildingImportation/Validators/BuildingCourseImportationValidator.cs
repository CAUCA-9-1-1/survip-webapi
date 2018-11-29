using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingCourseImportationValidator :
        AbstractValidator<BuildingCourse>
    {
        public BuildingCourseImportationValidator()
        {
            RuleFor(m => m.Id).NotNullOrEmpty();
            RuleFor(m => m.IdBuilding).OptionalKeyIsNullOrValid();
            RuleFor(m => m.IdFirestation).RequiredKeyIsValid();
            RuleForEach(m => m.Lanes).SetValidator(new BuildingCourseLaneValidator());
        }
    }
}