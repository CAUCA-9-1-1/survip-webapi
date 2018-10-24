using System.Collections.Generic;
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

	public class UnitOfMeasure : BaseImportedModel
	{
		public string Abbreviation { get; set; }
		public MeasureType MeasureType { get; set; }
		public List<UnitOfMeasureLocalization> Localizations { get; set; }
	}
}
