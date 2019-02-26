using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportInspectionGroupHandler : BaseReportGroupHandler<InspectionForReport>
	{
		private readonly InspectionService service;
		private readonly InspectionSurveyAnswerService answerService;
		private static readonly string surveyPlaceholder = "SurveyAnswers";

		protected override ReportBuildingGroup Group => ReportBuildingGroup.Inspection;

		public ReportInspectionGroupHandler(InspectionService service, InspectionSurveyAnswerService answerService)
		{
			this.service = service;
			this.answerService = answerService;
		}

		protected override List<InspectionForReport> GetData(Guid idBuilding, string languageCode)
		{
			var list = new List<InspectionForReport>();
		    var inspection = service.GetBuildingLastCompletedInspection(idBuilding);
		    if (inspection != null)
		    {
                list.Add(inspection);
		    }

		    return list;
		}

		protected override string GetFilledTemplate(string groupTemplate, InspectionForReport entity, string languageCode)
		{
			var filledTemplate = base.GetFilledTemplate(groupTemplate, entity, languageCode);
			if (filledTemplate.Contains(surveyPlaceholder))
				filledTemplate = AddSurveyAnswers(entity, filledTemplate, languageCode);

			return filledTemplate;
		}

		private string AddSurveyAnswers(InspectionForReport entity, string filledTemplate, string languageCode)
		{
			var answers = answerService.GetInspectionQuestionSummaryListLocalized(entity.Id, languageCode);
			return filledTemplate.Replace($"@{Group.ToString()}.{surveyPlaceholder}@", GetSurveyText(answers));
		}

		private string GetSurveyText(List<InspectionSummaryCategoryForList> answers)
		{
			var surveyToText = "";
			foreach (var category in answers)
			{
				surveyToText += "<h3>" + category.Title + "</h3>\n";
				
				for (var i = 0; i < category.AnswerSummary.Count; i++)
					surveyToText = AddAnswer(category, i, surveyToText);
			}

			return surveyToText;
		}

		private static string AddAnswer(InspectionSummaryCategoryForList category, int i, string surveyToText)
		{
			var answer = category.AnswerSummary.ElementAt(i);
			if (answer.QuestionType == 4 && answer.ChildSurveyAnswerList.Count != 0)
			{
				surveyToText += "<h3>" + answer.QuestionTitle + " #" + (i + 1) + "</h3>\n";
				surveyToText += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
				foreach (var answerChild in answer.ChildSurveyAnswerList)
					surveyToText += AddAnswer(answerChild);
			}
			else
			{
				surveyToText += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
				surveyToText += AddAnswer(answer);
			}

			surveyToText += "</table>\n";
			return surveyToText;
		}

		private static string AddAnswer(InspectionQuestionForSummary answer)
		{
			var answerText = "";
			answerText += "<tr>\n";
			answerText += "<td style=\"width:5.5in\">" + answer.QuestionDescription + "</td>\n";
			answerText += "<td style=\"width:3.0in\">" + answer.Answer + "</td>\n";
			answerText += "</tr>\n";
			return answerText;
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			placeholders.Add(surveyPlaceholder);
			return (ReportBuildingGroup.Inspection.ToString(), placeholders);
		}
	}
}