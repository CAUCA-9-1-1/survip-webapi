using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
	public enum MeasureType
	{
		Weight,
		Length,
		Liquid
	}

	public class UnitOfMeasure : BaseModel
	{
		public string Abbreviation { get; set; }
		public MeasureType MeasureType { get; set; }

		public List<UnitOfMeasureLocalization> Localizations { get; set; }
	}
}
