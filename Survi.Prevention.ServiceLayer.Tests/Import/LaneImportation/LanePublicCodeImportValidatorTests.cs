using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Lane;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.LaneImportation
{
	public class LanePublicCodeImportValidatorTests : AbstractValidator<LanePublicCode>
	{
		private readonly LanePublicCodeValidator validator;

		public LanePublicCodeImportValidatorTests()
		{
			validator = new LanePublicCodeValidator();
		}

		[Fact]
		public void IdIsValidWhenNotEmpty()
		{
			validator.ShouldNotHaveValidationErrorFor(publicCode => publicCode.Id, "IdPublicCode");
		}

		[Theory]
		[InlineData("")]
		[InlineData("   ")]
		[InlineData(null)]
		public void IdIsNotValidWhenEmpty(string id)
		{
			validator.ShouldHaveValidationErrorFor(publicCode => publicCode.Id, id);
		}

		[Fact]
		public void CodeIsValidWhenNotEmpty()
		{
			validator.ShouldNotHaveValidationErrorFor(publicCode => publicCode.Code, "02");
		}

		[Theory]
		[InlineData("")]
		[InlineData("   ")]
		[InlineData(null)]
		[InlineData("LimitOf2character")]
		public void CodeIsInvalidWhenNullEmptyOrTooLong(string code)
		{
			validator.ShouldHaveValidationErrorFor(publicCode => publicCode.Code, code);
		}

		[Fact]
		public void AbbreviationIsValidWhenNotEmpty()
		{
			validator.ShouldNotHaveValidationErrorFor(publicCode => publicCode.Abbreviation, "2");
		}

		[Theory]
		[InlineData("")]
		[InlineData("   ")]
		[InlineData(null)]
		[InlineData("LimitOf2")]
		public void AbbreviationIsInvalidWhenNullEmptyOrTooLong(string abbreviation)
		{
			validator.ShouldHaveValidationErrorFor(publicCode => publicCode.Abbreviation, abbreviation);
		}

		[Fact]
		public void DescriptionIsValidWhenNotEmpty()
		{
			validator.ShouldNotHaveValidationErrorFor(publicCode => publicCode.Description, "lane public code");
		}

		[Theory]
		[InlineData("")]
		[InlineData("   ")]
		[InlineData(null)]
		[InlineData("TooLongDescriptionToValidate20")]
		public void DescriptionIsInvalidWhenNullEmptyOrTooLong(string description)
		{
			validator.ShouldHaveValidationErrorFor(genCode => genCode.Description, description);
		}
	}
}


