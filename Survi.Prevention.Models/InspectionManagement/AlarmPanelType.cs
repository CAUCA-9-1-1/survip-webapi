using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class AlarmPanelType : BaseModel
	{
		public ICollection<AlarmPanelTypeLocalization> Localizations { get; set; }
	}
}
