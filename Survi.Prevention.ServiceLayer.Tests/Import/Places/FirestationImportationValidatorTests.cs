using System;
using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class FirestationImportationValidatorTests
    {
        private readonly IValidator<Firestation> validator;

        public FirestationImportationValidatorTests()
        {
            validator = new FirestationImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdIsNullOrEmpty(string id)
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.Id, id);
        }

        [Fact]
        public void ValidationFailWhenIdBuildingIsEmptyGuid()
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.IdBuilding, Guid.Empty.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenIdFireSafetyDepartmentIsNullOrEmpty(string id)
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.IdFireSafetyDepartment, id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidationFailWhenNameIsNullOrEmpty(string name)
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.Name, name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("012345678901")]
        public void ValidationFailWhenPhoneNumberIsNullOrTooLong(string number)
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.PhoneNumber, number);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("012345678901")]
        public void ValidationFailWhenFaxNumberIsNullOrTooLong(string number)
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.FaxNumber, number);
        }

        [Fact]
        public void ValidationFailWhenEmailIsNull()
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.Email, null as string);
        }

        [Fact]
        public void ValidationFailWhenEmailIsTooLong()
        {
            validator.ShouldHaveValidationErrorFor(entity => entity.Email, new string('.', 101));
        }
    }
}