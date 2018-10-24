using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestionChoice : BaseModel, IEntityWithLocalizations<BaseLocalization<SurveyQuestionChoice>>
	{
		public int Sequence { get; set; }

		public Guid IdSurveyQuestion { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }

		public SurveyQuestion Question { get; set; }
		public SurveyQuestion NextQuestion { get; set; }
		public ICollection<SurveyQuestionChoiceLocalization> Localizations { get; set; } = new List<SurveyQuestionChoiceLocalization>();
	}

	public interface IEntityWithLocalizations<T>
	{
		ICollection<BaseLocalization<SurveyQuestionChoice>> Localizations { get; set; }
	};	
}
