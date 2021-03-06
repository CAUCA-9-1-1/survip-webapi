﻿using System.Collections.Generic;
using Survi.Prevention.Models.SurveyManagement;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;

namespace Survi.Prevention.ServiceLayer.Tests.Mocks
{
    public class SurveyQuestionDuplicatorMock : SurveyQuestionDuplicator
    {
	    public void UpdateQuestionIdParent(List<SurveyQuestionIdsConnector> dictionary, SurveyQuestion question)
	    {
		    SurveyQuestionConnectorList = dictionary;
		    UdapteQuestionIdParent(question);
	    }
    }
}
