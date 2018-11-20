using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestionChoice : BaseModel, IEntityWithLocalizations<BaseLocalization>
	{
		public int Sequence { get; set; }

		public Guid IdSurveyQuestion { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }

		public SurveyQuestion Question { get; set; }
		public SurveyQuestion NextQuestion { get; set; }
		public ICollection<SurveyQuestionChoiceLocalization> Localizations { get; set; } = new List<SurveyQuestionChoiceLocalization>();
		ICollection<BaseLocalization> IEntityWithLocalizations<BaseLocalization>.Localizations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}

	public interface IEntityWithLocalizations<T>
	{
		ICollection<BaseLocalization> Localizations { get; set; }
	};	
}
