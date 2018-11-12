using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.SurveyDuplicators
{
	public class SurveyDuplicator
	{
		public Survey DuplicateSurvey(Survey surveyToCopy, Guid idWebUserLastModifiedBy)
		{
			Survey newSurvey = DuplicateSurveyFields(surveyToCopy);
			newSurvey.IdWebUserLastModifiedBy = idWebUserLastModifiedBy;
			newSurvey.Localizations = DuplicateSurveyLocalizations(surveyToCopy.Localizations, newSurvey.Id, idWebUserLastModifiedBy);
			newSurvey.Questions = new SurveyQuestionDuplicator().DuplicateSurveyQuestions(surveyToCopy.Questions, newSurvey.Id, idWebUserLastModifiedBy);
			return newSurvey;
		}

		public Survey DuplicateSurveyFields(Survey surveyToCopy)
		{
			return new Survey { SurveyType = surveyToCopy.SurveyType};
		}

		public List<SurveyLocalization> DuplicateSurveyLocalizations(ICollection<SurveyLocalization> localizationsToCopy, Guid newIdSurvey, Guid idWebUserLastModifiedBy)
		{
			List<SurveyLocalization> newLocalizations = new List<SurveyLocalization>();
			localizationsToCopy.ToList().ForEach(localization => newLocalizations.Add(DuplicateSurveyLocalization(localization, newIdSurvey, idWebUserLastModifiedBy)));
			return newLocalizations;
		}

		public SurveyLocalization DuplicateSurveyLocalization(SurveyLocalization localizationToCopy, Guid newIdSurvey, Guid idWebUserLastModifiedBy)
		{
			string suffix = Localization.EnumResource.ResourceManager.GetString("Copy", System.Globalization.CultureInfo.GetCultureInfo(localizationToCopy.LanguageCode));
			return new SurveyLocalization { LanguageCode = localizationToCopy.LanguageCode, Name =  localizationToCopy.Name + suffix , IdParent = newIdSurvey, IdWebUserLastModifiedBy = idWebUserLastModifiedBy};
		}

	}
}
