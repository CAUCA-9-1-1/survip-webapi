using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
    public class BuildingParticularRiskPictureImportationValidator :
        AbstractValidator<BuildingParticularRiskPicture>
    {
        public BuildingParticularRiskPictureImportationValidator()
        {
            RuleFor(m => m.IdBuildingParticularRisk)
                .ForeignKeyExists();

            RuleFor(m => m.PictureData)
                .NotNullOrEmpty();

            RuleFor(m => m.MimeType)
                .NotNullOrEmpty();
        }
    }
}