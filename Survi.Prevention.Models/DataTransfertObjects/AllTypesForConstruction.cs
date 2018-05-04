using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class AllTypesForConstruction
    {
	    public List<GenericModelForDisplay> BuildingTypes { get; set; }
		public List<GenericModelForDisplay> BuildingSidingTypes { get; set; }
	    public List<GenericModelForDisplay> ConstructionFireResistanceTypes { get; set; }
	    public List<GenericModelForDisplay> ConstructionTypes { get; set; }
	    public List<GenericModelForDisplay> RoofMaterialTypes { get; set; }
	    public List<GenericModelForDisplay> RoofTypes { get; set; }
	}
}
