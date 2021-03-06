﻿using System;
using FluentValidation;

namespace Survi.Prevention.ServiceLayer.ValidationUtilities
{
	public static class FluentValidationCustomValidators
    {
        public static IRuleBuilderOptions<T, string> NotNullOrEmpty<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName}_EmptyValue");
        }

        public static IRuleBuilderOptions<T, byte[]> NotNullOrEmpty<T>(this IRuleBuilder<T, byte[]> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName}_EmptyValue");
        }

        public static IRuleBuilderOptions<T, string> RequiredKeyIsValid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("{PropertyName}_MissingValue")
                .NotEqual(Guid.Empty.ToString()).WithMessage("{PropertyName}_UnknownValue");
        }

        public static IRuleBuilderOptions<T, string> OptionalKeyIsNullOrValid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEqual(Guid.Empty.ToString()).WithMessage("{PropertyName}_UnknownValue");
        }

        public static IRuleBuilderOptions<T, string> NotNullOrEmptyWithMaxLength<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
        {
            return ruleBuilder.NotNullOrEmpty()
                .MaximumLength(maxLength).WithMessage("{PropertyName}_TooLong_{MaxLength}");
        }

	    public static IRuleBuilderOptions<T, string> NotNullMaxLength<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
	    {
		    return ruleBuilder
			    .NotNull().WithMessage("{PropertyName}_NullValue")
			    .MaximumLength(maxLength).WithMessage("{PropertyName}_TooLong_{MaxLength}");
	    }

		public static IRuleBuilderOptions<T, string> HasMinimumLengthWhenNotEmpty<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength)
		{
			return ruleBuilder
				.MinimumLength(minimumLength)
				.WithMessage("{PropertyName}_TooShort_{MinLength}");
		}

		public static IRuleBuilderOptions<T, int> HasValidYear<T>(this IRuleBuilder<T, int> ruleBuilder)
		{
			return ruleBuilder
				.GreaterThanOrEqualTo(2000).WithMessage("{PropertyName}_InvalidYear")
				.LessThanOrEqualTo(2100).WithMessage("{PropertyName}_InvalidYear");
		}
	}
}