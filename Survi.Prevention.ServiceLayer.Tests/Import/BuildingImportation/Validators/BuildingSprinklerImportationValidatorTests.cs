using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingSprinklerImportationValidatorTests
    {
        private readonly BuildingSprinklerImportationValidator validator;

        public BuildingSprinklerImportationValidatorTests()
        {
            validator = new BuildingSprinklerImportationValidator();
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
        public void ValidationFailWhenIdSprinklerTypeIsUnknown()
        {
            validator.ShouldHaveValidationErrorFor(m => m.IdSprinklerType, null as string);
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

        [Fact]
        public void ValidationFailWhenPipeLocationIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.PipeLocation, new string('.', 501));
        }

        [Fact]
        public void ValidationFailWhenCollectorLocationIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(m => m.CollectorLocation, new string('.', 501));
        }
    }
}