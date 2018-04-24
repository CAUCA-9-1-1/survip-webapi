using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
	public abstract class UnitOfMeasure : BaseModel
	{
		public string Abbreviation { get; set; }
		public List<UnitOfMeasureLocalization> Localizations { get; set; }
	}

	public class DiameterUnitOfMeasure : UnitOfMeasure
	{
	}

	public class RateUnitOfMeasure : UnitOfMeasure
	{
	}

	public class PressureUnitOfMeasure : UnitOfMeasure
	{
	}

	public class CapacityUnitOfMeasure : UnitOfMeasure
	{
	}

	public class DimensionUnitOfMeasure : UnitOfMeasure
	{
	}
}
