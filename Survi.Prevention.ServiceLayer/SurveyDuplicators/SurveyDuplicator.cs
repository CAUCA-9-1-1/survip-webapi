using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.SurveyDuplicators
{
	public class SurveyDuplicator
	{
		public Survey DuplicateSurvey(Survey surveyToCopy)
		{
			Survey newSurvey = DuplicateSurveyFields(surveyToCopy);
			newSurvey.Localizations = DuplicateSurveyLocalizations(surveyToCopy.Localizations, newSurvey.Id);
			newSurvey.Questions = new SurveyQuestionDuplicator().DuplicateSurveyQuestions(surveyToCopy.Questions, newSurvey.Id);
			return newSurvey;
		}

		public Survey DuplicateSurveyFields(Survey surveyToCopy)
		{
			return new Survey { SurveyType = surveyToCopy.SurveyType };
		}

		public List<SurveyLocalization> DuplicateSurveyLocalizations(ICollection<SurveyLocalization> localizationsToCopy, Guid newIdSurvey)
		{
			List<SurveyLocalization> newLocalizations = new List<SurveyLocalization>();
			localizationsToCopy.ToList().ForEach(localization => newLocalizations.Add(DuplicateSurveyLocalization(localization, newIdSurvey)));
			return newLocalizations;
		}

		public SurveyLocalization DuplicateSurveyLocalization(SurveyLocalization localizationToCopy, Guid newIdSurvey)
		{
			string suffix = Localization.EnumResource.ResourceManager.GetString("Copy", System.Globalization.CultureInfo.GetCultureInfo(localizationToCopy.LanguageCode));
			return new SurveyLocalization { LanguageCode = localizationToCopy.LanguageCode, Name =  localizationToCopy.Name + suffix , IdParent = newIdSurvey};
		}

	}
}
