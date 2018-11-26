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
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.Id, "IdbuildingPnap");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    public void IdIsNotValidWhenEmpty(string id)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.Id, id);
	    }

	    [Fact]
	    public void IdBuildingIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.IdBuilding, "IdBuilding");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    
	    public void IdBuildingIsNotValidWhenEmpty(string idBuilding)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.IdBuilding, idBuilding);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void DayResidentCountIsNotValidWhenInferiorThanZero(int dayResidentCount)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.DayResidentCount, dayResidentCount);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void DayResidentCountIsValidWhenEqualOrGreaterThanZero(int dayResidentCount)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.DayResidentCount, dayResidentCount);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void EveningResidentCountIsNotValidWhenInferiorThanZero(int eveningResidentCount)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.EveningResidentCount, eveningResidentCount);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void EveningResidentCountIsValidWhenEqualOrGreaterThanZero(int eveningResidentCount)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.EveningResidentCount, eveningResidentCount);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void NightResidentCountIsNotValidWhenInferiorThanZero(int nightResidentCount)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.NightResidentCount, nightResidentCount);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void NightResidentCountIsValidWhenEqualOrGreaterThanZero(int nightResidentCount)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.NightResidentCount, nightResidentCount);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void ContactNameIsValidWhenEmptyOrNotTooLong(string contactName)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.ContactName, contactName);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void ContactNameIsNotValidWhenEmptyOrTooLong(string contactName)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.ContactName, contactName);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void ContactPhoneNumberIsValidWhenEmptyOrNotTooLong(string contactPhoneNumber)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.ContactPhoneNumber, contactPhoneNumber);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void ContactPhoneNumberIsNotValidWhenEmptyOrTooLong(string contactPhoneNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.ContactPhoneNumber, contactPhoneNumber);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("123")]
	    public void FloorIsValidWhenEmptyOrNotTooLong(string floor)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.Floor, floor);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("3 caractères max")]
	    public void FloorIsNotValidWhenEmptyOrTooLong(string floor)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.Floor, floor);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void LocalIsValidWhenEmptyOrNotTooLong(string local)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.Local, local);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("10 caractères max")]
	    public void LocalIsNotValidWhenEmptyOrTooLong(string local)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.Local, local);
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("12345")]
	    public void PersonNameIsValidWhenEmptyOrNotTooLong(string personName)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.PersonName, personName);
	    }

	    [Theory]
	    [InlineData(null)]
	    [InlineData("Test de validation de la longueur d' un champs de type (chaine de caractères) de 100 caractères maximum. Celui-ci comprends une série de plus de 150 caractères")]
	    public void PersonNameIsNotValidWhenEmptyOrTooLong(string personName)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.PersonName, personName);
	    }

	    [Theory]
	    [InlineData(null)]
	    public void DescriptionIsNotValidWhenNull(string description)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.Description, description);
	    }
    }
}
