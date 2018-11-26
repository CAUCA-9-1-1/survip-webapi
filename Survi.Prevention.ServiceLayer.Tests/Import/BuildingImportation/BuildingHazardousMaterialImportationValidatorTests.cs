using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingHazardousMaterialImportationValidatorTests
    {
	    private readonly BuildingHazardousMaterialImportationValidator validator;

	    public BuildingHazardousMaterialImportationValidatorTests()
	    {		    		    
		    validator = new BuildingHazardousMaterialImportationValidator();
	    }

	    [Fact]
	    public void IdIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Id, "IdBuildingHazardousMaterial");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdIsNotValidWhenEmpty(string id)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Id, id);
	    }

	    [Fact]
	    public void IdBuildingIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.IdBuilding, "IdBuilding");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdBuildingIsNotValidWhenEmpty(string idBuilding)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.IdBuilding, idBuilding);
	    }

	    [Fact]
	    public void IdHazardousMaterialIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.IdHazardousMaterial, "IdHazardousMaterial");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdHazardousMaterialIsNotValidWhenEmpty(string idHazardousMaterial)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.IdHazardousMaterial, idHazardousMaterial);
	    }

	    [Fact]
	    public void IdMeasuringUnitIsNotValidWhenNullAndHasCapacity()
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.IdUnitOfMeasure, new BuildingHazardousMaterial {CapacityContainer = 1, IdUnitOfMeasure = null});
	    }

	    [Theory]
	    [InlineData("idMeasuringUnit")]
	    [InlineData(null)]
	    public void IdMeasuringUnitIsValidWhenNullAndNoCapacity(string idUnitOfMeasure)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.IdUnitOfMeasure, new BuildingHazardousMaterial {CapacityContainer = 0, IdUnitOfMeasure = idUnitOfMeasure});
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void ContainerCapacityIsNotValidWhenInferiorThanZero(decimal containerCapacity)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.CapacityContainer, containerCapacity);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void ContainerCapacityIsValidWhenEqualOrGreaterThanZero(decimal containerCapacity)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.CapacityContainer, containerCapacity);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void QuantityIsNotValidWhenInferiorThanZero(int quantity)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Quantity, quantity);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void QuantityIsValidWhenEqualOrGreaterThanZero(int quantity)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Quantity, quantity);
	    }

		[Theory]
		[InlineData(-1)]
		public void TankTypeIsNotValidWhenNullOrNotInTankTypeEnum(int tankType)
		{
			Assert.DoesNotContain(tankType, Enum.GetValues(typeof(StorageTankType)).Cast<int>());
		}

		[Theory]
		[InlineData(1)]
		public void TankTypeIsValidWhenInTankTypeEnum(int tankType)
		{
			Assert.Contains(tankType, Enum.GetValues(typeof(StorageTankType)).Cast<int>());
		}

		[Theory]
	    [InlineData("")]
	    [InlineData("container")]
	    public void ContainerIsValidWhenEmptyOrNotTooLong(string container)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Container, container);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void ContainerIsNotValidWhenEmptyOrTooLong(string container)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Container, container);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("SS")]
	    public void FloorIsValidWhenEmptyOrNotTooLong(string floor)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Floor, floor);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("4 caratères max")]
	    public void FloorIsNotValidWhenEmptyOrTooLong(string floor)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Floor, floor);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("100 caractères max")]
	    public void GasInletIsValidWhenEmptyOrNotTooLong(string gasInlet)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.GasInlet, gasInlet);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void GasInletIsNotValidWhenEmptyOrTooLong(string gasInlet)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.GasInlet, gasInlet);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("150 caractères max")]
	    public void PlaceIsValidWhenEmptyOrNotTooLong(string place)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Place, place);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void PlaceIsNotValidWhenEmptyOrTooLong(string place)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Place, place);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("15 caractères")]
	    public void SectorIsValidWhenEmptyOrNotTooLong(string sector)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Sector, sector);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void SectorIsNotValidWhenEmptyOrTooLong(string sector)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Sector, sector);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("50 caractères max")]
	    public void SupplyLineIsValidWhenEmptyOrNotTooLong(string supplyLine)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.SupplyLine, supplyLine);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void SupplyLineIsNotValidWhenEmptyOrTooLong(string supplyLine)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.SupplyLine, supplyLine);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("15 caractères")]
	    public void WallIsValidWhenEmptyOrNotTooLong(string wall)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Wall, wall);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void WallIsNotValidWhenEmptyOrTooLong(string wall)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.Wall, wall);
	    }

	    [Theory]
	    [InlineData(null)]
	    public void SecurityPerimeterIsNotValidWhenNull(string securityPerimeter)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.SecurityPerimeter, securityPerimeter);
	    }

	    [Theory]
	    [InlineData("")]
	    public void SecurityPerimeterIsValidWhenEmpty(string securityPerimeter)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.SecurityPerimeter, securityPerimeter);
	    }

	    [Theory]
	    [InlineData(null)]
	    public void OtherInformationIsNotValidWhenNull(string otherInformation)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.OtherInformation, otherInformation);
	    }

	    [Theory]
	    [InlineData("")]
	    public void OtherInformationIsValidWhenEmpty(string otherInformation)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingHazardousMaterial => buildingHazardousMaterial.OtherInformation, otherInformation);
	    }


    }
}
