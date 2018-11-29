using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.TestHelper;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BuildingImportation.Validators
{
    public class BuildingCourseImportationValidatorTests
    {
        private readonly BuildingCourseImportationValidator validator;

        public BuildingCourseImportationValidatorTests()
        {
            ValidatorOptions.DisplayNameResolver = (type, memberInfo, expression) => memberInfo.Name;
            validator = new BuildingCourseImportationValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void InvalidWhenIdFirestationIsNotSetOrInvalid(string id)
        {
            validator.ShouldHaveValidationErrorFor(c => c.IdFirestation, id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void InvalidWhenIdIsNotSetOrInvalid(string id)
        {
            validator.ShouldHaveValidationErrorFor(c => c.Id, id);
        }

        [Fact]
        public void InvalidWhenIdBuildingIsEmptyGuid()
        {
            validator.ShouldHaveValidationErrorFor(c => c.IdBuilding, Guid.Empty.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void ValidWhenIdBuildingEmptyOrNull(string id)
        {
            validator.ShouldNotHaveValidationErrorFor(c => c.IdBuilding, id);
        }

        [Fact]
        public void InvalidWhenDirectionIsUnknown()
        {
            var lane = new BuildingCourseLane {Direction = (CourseLaneDirection) 11, IdLane = "value", Sequence = 0};
            var course = GenerateBuildingCourse(lane);

            var result = validator.Validate(course);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Direction_InvalidValue");
        }

        private static BuildingCourse GenerateBuildingCourse(BuildingCourseLane lane)
        {
            var course = new BuildingCourse
            {
                Lanes = new List<BuildingCourseLane> {lane},
                Id = "Id",
                IdBuilding = "Id",
                IdFirestation = "Id"
            };
            return course;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void InvalidWhenIdLaneIsUnknownOrMissing(string idLane)
        {
            var lane = new BuildingCourseLane { Direction =  CourseLaneDirection.Left, IdLane = idLane, Sequence = 0 };
            var course = GenerateBuildingCourse(lane);

            var result = validator.Validate(course);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "IdLane_MissingValue" || error.ErrorMessage == "IdLane_UnknownValue");
        }

        [Fact]
        public void InvalidWhenSequenceIsLowerThanZero()
        {
            var lane = new BuildingCourseLane { Direction = CourseLaneDirection.Left, IdLane = "value", Sequence = -1 };
            var course = GenerateBuildingCourse(lane);

            var result = validator.Validate(course);
            Assert.Contains(result.Errors, error => error.ErrorMessage == "Sequence_InvalidValue");
        }

        [Fact]
        public void ValidWhenAllFieldAreCorrectlySet()
        {
            var lane = new BuildingCourseLane {Direction = CourseLaneDirection.Left, IdLane = "value", Sequence = 1};
            var course = GenerateBuildingCourse(lane);

            var result = validator.Validate(course);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void LaneAreCorrectlyValidated()
        {
            validator.ShouldHaveChildValidator(m => m.Lanes, typeof(AbstractValidator<BuildingCourseLane>));
        }
    }
}