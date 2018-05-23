using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer
{
	public class RecursiveInspectionQuestionProcess
	{
		public List<InspectionQuestionForSummary> GroupRecursiveQuestion(List<InspectionQuestionForSummary> answers)
		{
			List<InspectionQuestionForSummary> recursiveList = new List<InspectionQuestionForSummary>();
			InspectionQuestionForSummary recursiveQuestion = null;
			bool recon = false;
			answers.ForEach(item =>
			{
				if (recursiveQuestion != null && item.Id == recursiveQuestion.Id && recon)
					recon = false;

				if (item.IsRecursive)
				{
					recursiveQuestion = item;
					recursiveList.Add(item);
					recursiveList[recursiveList.Count - 1].RecursiveAnswer = new List<InspectionQuestionForSummary>();
					recon = true;
				}
				if (recursiveQuestion != null && item.Id != recursiveQuestion.Id && recon)
				{
					if (item.QuestionTitle == recursiveQuestion.QuestionTitle)
						recursiveList[recursiveList.Count - 1].RecursiveAnswer.Add(item);
					else
						recon = false;
				}

				if (!recon)
					recursiveList.Add(item);

			});

			return recursiveList;
		}
	}
}
