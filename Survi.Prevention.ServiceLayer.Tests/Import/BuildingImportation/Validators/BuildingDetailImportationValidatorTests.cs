using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingDetailImportationValidatorTests
    {
        private readonly BuildingDetailImportationValidator validator;

        public BuildingDetailImportationValidatorTests()
        {
            validator = new BuildingDetailImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdBuildingIsInvalid(string idBuilding)
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdBuilding, idBuilding);
        }

        [Fact]
        public void ValidationFailWhenWaterFlowUnitIsMissingAndWaterFlowIsSet()
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdUnitOfMeasureEstimatedWaterFlow, new BuildingDetail {IdUnitOfMeasureEstimatedWaterFlow = null, EstimatedWaterFlow = 2});
        }

        [Fact]
        public void ValidationFailWhenHeightUnitIsMissingAndHeightIsSet()
        {
            validator.ShouldHaveValidationErrorFor(code => code.IdUnitOfMeasureHeight, new BuildingDetail { IdUnitOfMeasureHeight = null, Height = 2 });
        }

        [Fact]
        public void ValidationFailWhenPictureDataIsSetAndThereIsNoMimeType()
        {
            validator.ShouldHaveValidationErrorFor(code => code.MimeType, new BuildingDetail { MimeType = null, PictureData =new byte[2] });
        }

        [Fact]
        public void ValidationDoesntFailWhenPictureDataIsSetAndThereIsNoMimeType()
        {
            validator.ShouldNotHaveValidationErrorFor(code => code.MimeType, new BuildingDetail { MimeType = null, PictureData = null });
        }

        [Fact]
        public void ValidationFailWhenGarageTypeIsNotAKnowType()
        {
            validator.ShouldHaveValidationErrorFor(code => code.GarageType, new BuildingDetail { GarageType = (GarageType)10 });
        }
    }
}