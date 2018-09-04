using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer 
{
	public class ReportPlaceholders
	{
		/*
		 * Inspection
		 */
		public string RiskCategory { get; set; }
		public string Assignment { get; set; }
		public string Matricule { get; set; }
		public string Alias { get; set; }
		public string Lane { get; set; }
		public string Transversal { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
		public string ImplementationPlan { get; set; }
		public string Survey { get; set; }

		/*
		 * Building
		 */
		public string BuildingType { get; set; }
		public string BuildingGarage { get; set; }
		public string BuildingHeight { get; set; }
		public string BuildingEstimatedWaterFlow { get; set; }
		public string ConstructionType { get; set; }
		public string ConstructionFireResistance { get; set; }
		public string ConstructionSiding { get; set; }
		public string RoofType { get; set; }
		public string RoofMaterial { get; set; }




		/*public void SetGeneralInformation(BuildingGeneralInformationForReport generalInformation)
		{
			RiskCategory = generalInformation.RiskCategory;
			Matricule = generalInformation.Matricule;
			Address = generalInformation.Address;
			ZipCode = generalInformation.ZipCode;
			Lane = generalInformation.Lane;
			Alias = generalInformation.Alias;
			Assignment = generalInformation.Assignment;
		}*/

		/*public void SetBuildingDetails(BuildingDetailForReport details)
		{
			BuildingType = details.BuildingType;
			BuildingGarage = details.GarageTypeLocalized;
			BuildingHeight = $"{details.BuildingHeight: f2}";
			BuildingEstimatedWaterFlow = details.EstimatedWaterFlow.ToString();
			ConstructionType = details.ConstructionTypeLocalized;
			ConstructionFireResistance = details.ConstructionFireResistanceLocalized;
			ConstructionSiding = details.ConstructionSidingLocalized;
			RoofType = details.RoofTypeLocalized;
			RoofMaterial = details.RoofMaterialLocalized;
		}*/

		public void SetSurvey(List<InspectionSummaryCategoryForList> groupedTitle)
		{
			var surveyToText = "";
			foreach (var category in groupedTitle)
			{
				surveyToText += "<h3>" + category.Title + "</h3>\n";
				surveyToText += "<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"width:8.5in\">\n";
				surveyToText += "<tbody>\n";
				for (var i = 0; i < category.AnswerSummary.Count; i++)
				{
					var recursive = category.AnswerSummary.ElementAt(i);
					if (recursive.IsRecursive && recursive.RecursiveAnswer.Count != 0)
					{
						surveyToText += "<h3>" + recursive.QuestionTitle + " #" + (i + 1) + "</h3>\n";
						foreach (var question in recursive.RecursiveAnswer)
						{
							surveyToText += "<tr>\n";
							surveyToText += "<td style=\"width:5.5in\">\t" + question.QuestionDescription + "</td>\n";
							surveyToText += "<td style=\"width:3.0in\">\t" + question.Answer + "</td>\n";
							surveyToText += "</tr>\n";
						}
					}
					else
					{
						surveyToText += "<tr>\n";
						surveyToText += "<td style=\"width:5.5in\">" + recursive.QuestionDescription + "</td>\n";
						surveyToText += "<td style=\"width:3.0in\">" + recursive.Answer + "</td>\n";
						surveyToText += "</tr>\n";
					}
				}

				surveyToText += "</tbody>\n";
				surveyToText += "</table>\n";
			}

			Survey = surveyToText;
		}
	}
}
