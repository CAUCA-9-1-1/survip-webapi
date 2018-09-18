using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer
{
    public class InspectionSurveyTreeGenerator
    {
	    public List<InspectionQuestionForList> GetSurveyQuestionTreeList(List<InspectionQuestionForList> surveyQuestion)
	    {
		    List<InspectionQuestionForList> questionTreetList = new List<InspectionQuestionForList>();
		    questionTreetList.AddRange(surveyQuestion.Where(sq=>sq.IdParent == null));
		    questionTreetList.ForEach(parentQuestion =>
			{
				var children = surveyQuestion.Where(sq => sq.IdParent == parentQuestion.IdSurveyQuestion).OrderBy(sq=>sq.Sequence).ToList();
				if (children.Any())
				{
					parentQuestion.ChildSurveyAnswerList = new List<InspectionQuestionForList>();
					parentQuestion.ChildSurveyAnswerList.AddRange(children);
				}
			});
		    return questionTreetList;
	    }

	    public List<InspectionQuestionForList> GetSurveyAnswerTreeList(List<InspectionQuestionForList> surveyAnswer)
	    {
		    List<InspectionQuestionForList> answerTreeList = new List<InspectionQuestionForList>();
		    answerTreeList.AddRange(surveyAnswer.Where(sq=>sq.IdParent == null).OrderBy(sq=>sq.Sequence));
		    answerTreeList.ForEach(parentAnswer =>
		    {
			    var children = surveyAnswer.Where(sq => string.Equals(sq.IdParent.ToString(), parentAnswer.Id.ToString(), StringComparison.CurrentCultureIgnoreCase)).OrderBy(sq=>sq.Sequence).ToList();
			    if (children.Any())
			    {
				    parentAnswer.ChildSurveyAnswerList = new List<InspectionQuestionForList>();
				    parentAnswer.ChildSurveyAnswerList.AddRange(children);
			    }
		    });
		    return answerTreeList;
	    }

	    public List<InspectionQuestionForSummary> GetSurveySummaryTreeList(List<InspectionQuestionForSummary> surveyAnswer)
	    {
		    List<Guid> idsToRemove = new List<Guid>();
		    List<InspectionQuestionForSummary> answerTreeList = new List<InspectionQuestionForSummary>();
		    answerTreeList.AddRange(surveyAnswer.Where(sq=>sq.IdParent == null));
		    answerTreeList.ForEach(parentAnswer =>
		    {
			    var children = surveyAnswer.Where(sq => string.Equals(sq.IdParent.ToString(), parentAnswer.Id.ToString(), StringComparison.CurrentCultureIgnoreCase)).OrderBy(sq=>sq.Sequence).ToList();
			    if (children.Any())
			    {
				    parentAnswer.ChildSurveyAnswerList = new List<InspectionQuestionForSummary>();
				    parentAnswer.ChildSurveyAnswerList.AddRange(children);
			    }
			    else
			    {
				    idsToRemove.Add(parentAnswer.Id);
			    }
		    });


			idsToRemove.ForEach(id =>
			{
				if (answerTreeList.Find(atl => atl.Id == id) != null)
					answerTreeList.Remove(answerTreeList.Find(atl => atl.Id == id));
			});
		    return answerTreeList;
	    }
    }
}
