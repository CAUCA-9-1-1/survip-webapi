using FluentValidation;

namespace Survi.Prevention.ServiceLayer.ValidationUtilities
{
    public static class FluentValidationCustomValidators
    {
        public static IRuleBuilderOptions<T, string> NotNullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName}_EmptyValue");
        }

        public static IRuleBuilderOptions<T, string> ForeignKeyExists<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName}_UnknownRelation");
        }

        public static IRuleBuilderOptions<T, string> NotNullOrEmptyWithMaxLength<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
        {
            return ruleBuilder.NotNullOrEmpty()
                .MaximumLength(maxLength).WithMessage("{PropertyName}_InvalidValue");
        }

	    public static IRuleBuilderOptions<T, string> NotNullMaxLength<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
	    {
		    return ruleBuilder
			    .NotNull().WithMessage("{PropertyName}_NullValue")
			    .MaximumLength(maxLength).WithMessage("{PropertyName}_InvalidValue");
	    }
    }
}