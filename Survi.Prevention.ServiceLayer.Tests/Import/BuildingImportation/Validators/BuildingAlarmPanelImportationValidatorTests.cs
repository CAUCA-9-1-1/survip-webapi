using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingAlarmPanelImportationValidatorTests
    {
        private readonly BuildingAlarmPanelImportationValidator validator;

        public BuildingAlarmPanelImportationValidatorTests()
        {
            validator = new BuildingAlarmPanelImportationValidator();
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
        public void ValidationFailWhenIdAlarmPanelTypeIsUnknown()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdAlarmPanelType, null as string);
        }

        [Fact]
        public void ValidationFailWhenFloorIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Floor, new string('.', 101));
        }

        [Fact]
        public void ValidationFailWhenWallIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Wall, new string('.', 101));
        }

        [Fact]
        public void ValidationFailWhenSectorIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Sector, new string('.', 101));
        }
    }
}