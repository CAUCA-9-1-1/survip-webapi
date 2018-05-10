using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class SurveyQuestionChoiceForList
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }
		public int Sequence { get; set; }
	}
}
