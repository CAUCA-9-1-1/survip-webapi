using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class Survey : BaseModel
	{
		public int SurveyType { get; set; }
		
		public ICollection<SurveyLocalization> Localizations { get; set; }
		public ICollection<SurveyQuestion> Questions { get; set; }
	}
}