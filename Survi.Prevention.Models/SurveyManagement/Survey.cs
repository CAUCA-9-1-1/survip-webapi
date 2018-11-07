using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class Survey : BaseModel
	{
		public int SurveyType { get; set; }
		
		public ICollection<SurveyLocalization> Localizations { get; set; } = new List<SurveyLocalization>();
		public ICollection<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();
	}
}