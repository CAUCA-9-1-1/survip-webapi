using FluentValidation;
using NetTopologySuite.Geometries;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Validators
{
	public class BuildingImportationValidator : BaseImportWithPictureValidator<Building>
	{
		public BuildingImportationValidator()
		{
			RuleFor(m => m.Id)
				.NotNullOrEmpty();

			RuleFor(m => m.IdCity)
				.RequiredKeyIsValid();

			RuleFor(m => m.IdLane)
				.RequiredKeyIsValid();

			RuleFor(m => m.IdRiskLevel)
				.RequiredKeyIsValid();

			RuleFor(m => m.CivicNumber)
				.NotNullOrEmptyWithMaxLength(15);

			RuleFor(m => m.CivicLetter)
				.NotNullMaxLength(10);

			RuleFor(m => m.CivicLetterSupp)
				.NotNullMaxLength(10);

			RuleFor(m => m.CivicSupp)
				.NotNullMaxLength(10);

			RuleFor(m => m.AppartmentNumber)
				.NotNullMaxLength(10);

			RuleFor(m => m.Floor)
				.NotNullMaxLength(10);

			RuleFor(m => m.NumberOfFloor)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.NumberOfAppartment)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.NumberOfBuilding)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.YearOfConstruction)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.BuildingValue)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.PostalCode)
				.NotNullMaxLength(6);

			RuleFor(m => m.Suite)
				.GreaterThanOrEqualTo(0).WithMessage("{PropertyName}_InferiorToZeroValue");

			RuleFor(m => m.Source)
				.NotNullMaxLength(25);

			RuleFor(m => m.UtilisationDescription)
				.NotNullMaxLength(255);

			RuleFor(m => m.Matricule)
				.NotNullMaxLength(18);

			RuleFor(m => m.WktCoordinates)
				.NotNullMaxLength(50);

			RuleFor(m => m.WktCoordinates)
				.Must(BeAValidWktCoordinate)
				.When(m=>!string.IsNullOrWhiteSpace(m.WktCoordinates));

			RuleFor(m => m.CoordinatesSource)
				.NotNullMaxLength(50);

			RuleFor(m => m.Details)
				.NotNull().WithMessage("{PropertyName_InvalidValue}");

			RuleFor(m => m.ChildType)
				.IsInEnum();
		}

		private bool BeAValidWktCoordinate(string coordinate)
		{
			return ReadCoordinate(coordinate) != null;
		}

		private static Point ReadCoordinate(string coordinate)
		{
			try
			{
				if (string.IsNullOrEmpty(coordinate))
					return null;

				var r = new NetTopologySuite.IO.WKTReader {DefaultSRID = 4326, HandleOrdinates = GeoAPI.Geometries.Ordinates.XY};
				var vr = r.Read(coordinate) as Point;
				return vr;
			}
			catch
			{
				return null;
			}
		}
	}
}
