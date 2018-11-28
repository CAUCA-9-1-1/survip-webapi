using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingContactImportationValidatorTests: BaseImportValidatorMethodTests
    {
	    private readonly BuildingContactImportationValidator validator;

	    public BuildingContactImportationValidatorTests()
	    {		    		    
		    validator = new BuildingContactImportationValidator();
	    }

	    [Fact]
	    public void IdIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.Id, "IdbuildingContact");
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

	    [Fact]
	    public void FirstNameIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.FirstName, "firstName");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:31)]
	    public void FirstNameIsNotValidWhenEmptyOrTooLong(string firstName)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.FirstName, firstName);
	    }

	    [Fact]
	    public void LastNameIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.LastName, "firstName");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:31)]
	    public void LastNameIsNotValidWhenEmptyOrTooLong(string lastName)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.LastName, lastName);
	    }

	    [Fact]
	    public void PhoneNumberIsValidWhenNotEmpty()
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.PhoneNumber, "5555555555");
	    }

	    [Theory]
	    [InlineData("")]
	    [InlineData("   ")]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void PhoneNumberIsNotValidWhenEmptyOrIncorrect(string phoneNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.PhoneNumber, phoneNumber);
	    }

	    [Theory]
	    [InlineData(-1)]
	    public void CallPriorityIsNotValidWhenInferiorThanZero(int callPriority)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.CallPriority, callPriority);
	    }

	    [Theory]
	    [InlineData(1)]
	    [InlineData(0)]
	    public void CallPriorityIsValidWhenEqualOrGreaterThanZero(int callPriority)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.CallPriority, callPriority);
	    }

	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void PhoneNumberExtensionIsValidWhenEmptyOrNotTooLong(string phoneExtension)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.PhoneNumberExtension, phoneExtension);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void PhoneNumberExtensionIsNotValidWhenEmptyOrTooLong(string phoneExtension)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.PhoneNumberExtension, phoneExtension);
	    }

		
	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void PagerNumberIsValidWhenEmptyOrNotTooLong(string pagerNumber)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.PagerNumber, pagerNumber);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void PagerNumberIsNotValidWhenEmptyOrTooLong(string pagerNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.PagerNumber, pagerNumber);
	    }
		
	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void PagerCodeExtensionIsValidWhenEmptyOrNotTooLong(string pagerCode)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.PagerCode, pagerCode);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void PagerCodeIsNotValidWhenEmptyOrTooLong(string pagerCode)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.PagerCode, pagerCode);
	    }
		
	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:10)]
	    public void CellNumberExtensionIsValidWhenEmptyOrNotTooLong(string cellNumber)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.CellphoneNumber, cellNumber);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void CellNumberIsNotValidWhenEmptyOrTooLong(string cellNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.CellphoneNumber, cellNumber);
	    }
		
	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:10)]
	    public void OtherPhoneNumberExtensionIsValidWhenEmptyOrNotTooLong(string otherNumber)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.OtherNumber, otherNumber);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void OtherPhoneNumberIsNotValidWhenEmptyOrTooLong(string otherNumber)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.OtherNumber, otherNumber);
	    }
		
	    [Theory]
	    [InlineData("")]
	    [MemberData(nameof(GetMaxLengthString), parameters:5)]
	    public void OtherPhoneExtensionIsValidWhenEmptyOrNotTooLong(string otherNumberExtension)
	    {
		    validator.ShouldNotHaveValidationErrorFor(buildingContact => buildingContact.OtherNumberExtension, otherNumberExtension);
	    }

	    [Theory]
	    [InlineData(null)]
	    [MemberData(nameof(GetMaxLengthString), parameters:11)]
	    public void OtherPhoneExtensionIsNotValidWhenEmptyOrTooLong(string otherNumberExtension)
	    {
		    validator.ShouldHaveValidationErrorFor(buildingContact => buildingContact.OtherNumberExtension, otherNumberExtension);
	    }

	    
    }
}
