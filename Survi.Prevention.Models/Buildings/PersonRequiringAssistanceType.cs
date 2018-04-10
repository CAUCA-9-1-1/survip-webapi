using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class PersonRequiringAssistanceType : BaseModel
	{
		public ICollection<PersonRequiringAssistanceTypeLocalization> Localizations { get; set; }
	}
}
