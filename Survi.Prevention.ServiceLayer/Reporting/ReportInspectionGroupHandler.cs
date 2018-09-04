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
		private readonly InspectionQuestionService answerService;
		private readonly string surveyPlaceholder = "SurveyAnswers";

		protected override ReportBuildingGroup Group => ReportBuildingGroup.Inspection;

		public ReportInspectionGroupHandler(InspectionService service, InspectionQuestionService answerService)
		{
			this.service = service;
			this.answerService = answerService;
		}

		protected override List<InspectionForReport> GetData(Guid idBuilding, string languageCode)
		{
			return new List<InspectionForReport> {service.GetBuildingLastCompletedInspection(idBuilding)};
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
			return filledTemplate.Replace("{{" + surveyPlaceholder + "}}", GetSurveyText(answers));
		}

		private string GetSurveyText(List<InspectionSummaryCategoryForList> answers)
		{
			var surveyToText = "";
			foreach (var category in answers)
			{
				surveyToText += "<h3>" + category.Title + "</h3>\n";
				surveyToText += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
				surveyToText += "<tbody>\n";

				for (var i = 0; i < category.AnswerSummary.Count; i++)
					surveyToText = AddAnswer(category, i, surveyToText);

				surveyToText += "</tbody>\n";
				surveyToText += "</table>\n";
			}

			return surveyToText;
		}

		private static string AddAnswer(InspectionSummaryCategoryForList category, int i, string surveyToText)
		{
			var recursive = category.AnswerSummary.ElementAt(i);
			if (recursive.IsRecursive && recursive.RecursiveAnswer.Count != 0)
			{
				surveyToText += "<h3>" + recursive.QuestionTitle + " #" + (i + 1) + "</h3>\n";
				foreach (var answer in recursive.RecursiveAnswer)
					surveyToText += AddAnswer(answer);
			}
			else
				surveyToText = AddAnswer(recursive);

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
	}
}