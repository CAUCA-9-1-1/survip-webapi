using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation
{
    public class BuildingPnapImportationValidatorTests
    {
	    private readonly BuildingPnapImportationValidator validator;

	    public BuildingPnapImportationValidatorTests()
	    {		    		    
		    validator = new BuildingPnapImportationValidator();
	    }

	    [Fact]
	    public void IdIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.Id, "IdbuildingPnap");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdIsNotValidWhenEmpty(string id)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.Id, id);
	    }

	    [Fact]
	    public void IdBuildingIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.IdBuilding, "IdBuilding");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    
	    public void IdBuildingIsNotValidWhenEmpty(string idBuilding)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.IdBuilding, idBuilding);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void DayResidentCountIsNotValidWhenInferiorThanZero(int dayResidentCount)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.DayResidentCount, dayResidentCount);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void DayResidentCountIsValidWhenEqualOrGreaterThanZero(int dayResidentCount)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.DayResidentCount, dayResidentCount);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void EveningResidentCountIsNotValidWhenInferiorThanZero(int eveningResidentCount)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.EveningResidentCount, eveningResidentCount);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void EveningResidentCountIsValidWhenEqualOrGreaterThanZero(int eveningResidentCount)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.EveningResidentCount, eveningResidentCount);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void NightResidentCountIsNotValidWhenInferiorThanZero(int nightResidentCount)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.NightResidentCount, nightResidentCount);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void NightResidentCountIsValidWhenEqualOrGreaterThanZero(int nightResidentCount)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.NightResidentCount, nightResidentCount);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void ContactNameIsValidWhenEmptyOrNotTooLong(string contactName)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.ContactName, contactName);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void ContactNameIsNotValidWhenEmptyOrTooLong(string contactName)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.ContactName, contactName);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void ContactPhoneNumberIsValidWhenEmptyOrNotTooLong(string contactPhoneNumber)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.ContactPhoneNumber, contactPhoneNumber);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void ContactPhoneNumberIsNotValidWhenEmptyOrTooLong(string contactPhoneNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.ContactPhoneNumber, contactPhoneNumber);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("123")]
	    public void FloorIsValidWhenEmptyOrNotTooLong(string floor)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.Floor, floor);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("3 caractères max")]
	    public void FloorIsNotValidWhenEmptyOrTooLong(string floor)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.Floor, floor);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void LocalIsValidWhenEmptyOrNotTooLong(string local)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.Local, local);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("10 caractères max")]
	    public void LocalIsNotValidWhenEmptyOrTooLong(string local)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.Local, local);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void PersonNameIsValidWhenEmptyOrNotTooLong(string personName)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingPnap => buildingPnap.PersonName, personName);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void PersonNameIsNotValidWhenEmptyOrTooLong(string personName)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.PersonName, personName);
	    }

	    [Theory]
	    [InlineData(null)]
	    public void DescriptionIsNotValidWhenNull(string description)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingPnap => buildingPnap.Description, description);
	    }
    }
}
