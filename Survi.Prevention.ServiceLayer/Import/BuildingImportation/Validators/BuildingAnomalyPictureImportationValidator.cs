using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingAnomalyPictureImportationValidator :
        AbstractValidator<BuildingAnomalyPicture>
    {
        public BuildingAnomalyPictureImportationValidator()
        {
            RuleFor(m => m.Id)
                .NotNullOrEmpty();

            RuleFor(m => m.IdBuildingAnomaly)
                .RequiredKeyIsValid();

            RuleFor(m => m.PictureData)
                .NotNullOrEmpty();

            RuleFor(m => m.MimeType)
                .NotNullOrEmpty();
        }
    }
}