using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestionLocalization : BaseLocalization<SurveyQuestion>
	{
		public string Title { get; set; }
		public string Name { get; set; }
	}
}