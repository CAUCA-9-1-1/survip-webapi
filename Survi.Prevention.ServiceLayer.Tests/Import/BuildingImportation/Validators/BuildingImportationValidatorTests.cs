using System;
using System.Linq;
using FluentValidation.TestHelper;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingImportationValidatorTests: BaseImportValidatorMethodTests
    {
	    private readonly BuildingImportationValidator validator;

	    public BuildingImportationValidatorTests()
	    {		    		    
		    validator = new BuildingImportationValidator();
	    }

	    [Fact]
	    public void IdIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.Id, "Id");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdIsNotValidWhenEmpty(string id)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.Id, id);
	    }

	    [Fact]
	    public void IdCityIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.IdCity, "IdCity");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]	    
	    public void IdCityIsNotValidWhenEmpty(string idCity)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.IdCity, idCity);
	    }

	    [Fact]
	    public void IdRiskLevelIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.IdRiskLevel, "idRiskLevel");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]	    
	    public void IdRiskLevelIsNotValidWhenEmpty(string idRiskLevel)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.IdRiskLevel, idRiskLevel);
	    }

	    [Fact]
	    public void IdLaneIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.IdLane, "idLane");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdLaneIsNotValidWhenEmpty(string idLane)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.IdLane, idLane);
	    }

	    [Fact]
	    public void CivicNumberIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.CivicNumber, "civic number");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:16)]
	    public void CivicNumberIsNotValidWhenEmptyOrTooLong(string civicNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.CivicNumber, civicNumber);
	    }
	
	    [Theory]
	    [InlineData(-1)]
	    public void NumberOfFloorIsNotValidWhenInferiorThanZero(int numberOfFloor)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.NumberOfFloor, numberOfFloor);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void NumberOfFloorIsValidWhenEqualOrGreaterThanZero(int numberOfFloor)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.NumberOfFloor, numberOfFloor);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void NumberOfAppartmentIsNotValidWhenInferiorThanZero(int numberOfAppartment)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.NumberOfAppartment, numberOfAppartment);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void NumberOfAppartmentIsValidWhenEqualOrGreaterThanZero(int numberOfAppartment)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.NumberOfAppartment, numberOfAppartment);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void NumberOfBuildingIsNotValidWhenInferiorThanZero(int numberOfBuilding)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.NumberOfBuilding, numberOfBuilding);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void NumberOfBuildingIsValidWhenEqualOrGreaterThanZero(int numberOfBuilding)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.NumberOfBuilding, numberOfBuilding);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void YearOfConstructionIsNotValidWhenInferiorThanZero(int yearOfConstruction)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.YearOfConstruction, yearOfConstruction);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void YearOfConstructionIsValidWhenEqualOrGreaterThanZero(int yearOfConstruction)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.YearOfConstruction, yearOfConstruction);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void BuildingValueIsNotValidWhenInferiorThanZero(int buildingValue)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.BuildingValue, buildingValue);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void BuildingValueIsValidWhenEqualOrGreaterThanZero(int buildingValue)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.BuildingValue, buildingValue);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void SuiteIsNotValidWhenInferiorThanZero(int suite)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.Suite, suite);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void SuiteIsValidWhenEqualOrGreaterThanZero(int suite)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.Suite, suite);
	    }


	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void CivicLetterIsValidWhenEmptyOrNotTooLong(string civicLetter)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.CivicLetter, civicLetter);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void CivicLetterIsNotValidWhenEmptyOrTooLong(string civicLetter)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.CivicLetter, civicLetter);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void CivicSuppIsValidWhenEmptyOrNotTooLong(string civicSupp)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.CivicSupp, civicSupp);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void CivicSuppIsNotValidWhenEmptyOrTooLong(string civicSupp)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.CivicSupp, civicSupp);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void CivicLetterSuppIsValidWhenEmptyOrNotTooLong(string civicLetterSupp)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.CivicLetterSupp, civicLetterSupp);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void CivicLetterSuppIsNotValidWhenEmptyOrTooLong(string civicLetterSupp)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.CivicLetterSupp, civicLetterSupp);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void AppartmentNumberIsValidWhenEmptyOrNotTooLong(string appartmentNumber)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.AppartmentNumber, appartmentNumber);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void AppartmentNumberIsNotValidWhenEmptyOrTooLong(string appartmentNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.AppartmentNumber, appartmentNumber);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void FloorIsValidWhenEmptyOrNotTooLong(string floor)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.Floor, floor);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void FloorIsNotValidWhenEmptyOrTooLong(string floor)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.Floor, floor);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void PostalCodeIsValidWhenEmptyOrNotTooLong(string postalCode)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.PostalCode, postalCode);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:7)]
	    public void PostalCodeIsNotValidWhenEmptyOrTooLong(string postalCode)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.PostalCode, postalCode);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void SourceIsValidWhenEmptyOrNotTooLong(string source)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.Source, source);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:26)]
	    public void SourceIsNotValidWhenEmptyOrTooLong(string source)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.Source, source);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void UtilisationDescriptionIsValidWhenEmptyOrNotTooLong(string utilisationDescription)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.UtilisationDescription, utilisationDescription);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:256)]
	    public void UtilisationDescriptionIsNotValidWhenEmptyOrTooLong(string utilisationDescription)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.UtilisationDescription, utilisationDescription);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void MatriculeIsValidWhenEmptyOrNotTooLong(string matricule)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.Matricule, matricule);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:19)]
	    public void MatriculeIsNotValidWhenEmptyOrTooLong(string matricule)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.Matricule, matricule);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("Point(0 0)")]
	    public void CoordinatesIsValidWhenEmptyOrHasValidFormat(string wktCoordinates)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.WktCoordinates, wktCoordinates);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    [MemberData(nameof(GetMaxLengthString), parameters:51)]
	    public void CoordinatesIsNotValidWhenNullOrHasNotInvalidFormat(string wktCoordinates)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.WktCoordinates, wktCoordinates);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void CoordinatesSourceIsValidWhenEmptyOrNotTooLong(string coordinatesSource)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.CoordinatesSource, coordinatesSource);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:51)]
	    public void CoordinatesSourceIsNotValidWhenEmptyOrTooLong(string coordinatesSource)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.CoordinatesSource, coordinatesSource);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void DetailsIsValidWhenEmpty(string details)
	    {
		    validator.ShouldNotHaveValidationErrorFor(building => building.Details, details);
	    }

	    [Theory]
	    [InlineData(null)]
	    public void DetailsIsNotValidWhenEmpty(string details)
	    {
		    validator.ShouldHaveValidationErrorFor(building => building.Details, details);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void ChildTypeIsNotValidWhenNullOrNotInTankTypeEnum(int childType)
	    {
		    Assert.DoesNotContain(childType, Enum.GetValues(typeof(BuildingChildType)).Cast<int>());
	    }

	    [Theory]
	    [InlineData(1)]
	    public void ChildTypeIsValidWhenInTankTypeEnum(int childType)
	    {
		    Assert.Contains(childType, Enum.GetValues(typeof(BuildingChildType)).Cast<int>());
	    }
    }
}
