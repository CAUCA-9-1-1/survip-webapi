using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
	public enum MeasureType
	{
		Rate,
		Pressure,
		Diameter,
		Capacity,
		Dimension
	}

	public class UnitOfMeasure : BaseLocalizableImportedModel<UnitOfMeasureLocalization>
	{
		public string Abbreviation { get; set; }
		public MeasureType MeasureType { get; set; }
	}
}
