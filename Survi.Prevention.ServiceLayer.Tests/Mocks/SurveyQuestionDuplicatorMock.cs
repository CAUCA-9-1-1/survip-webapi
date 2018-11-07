using System;
using System.Collections.Generic;
using System.Text;
using Survi.Prevention.Models.SurveyManagement;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;

namespace Survi.Prevention.ServiceLayer.Tests.Mocks
{
    public class SurveyQuestionDuplicatorMock : SurveyQuestionDuplicator
    {
	    public void UpdatePatente(List<SurveyQuestionConnector> dictionary, SurveyQuestion question)
	    {
		    surveyQuestionConnectorList = dictionary;
		    UdapteQuestionIdParent(question);
	    }
    }
}
