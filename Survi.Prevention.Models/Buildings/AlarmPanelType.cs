using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class AlarmPanelType : BaseModel
	{
		public ICollection<AlarmPanelTypeLocalization> Localizations { get; set; }
	}
}
