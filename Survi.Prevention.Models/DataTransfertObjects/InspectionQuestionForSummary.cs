﻿using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionQuestionForSummary
	{
		public Guid Id { get; set; }
		public Guid NextQuestionId { get; set; }
		public string QuestionTitle { get;  set; } = "";
		public string QuestionDescription { get; set; } = "";
		public string Answer { get; set; } = "";
		public int QuestionType { get; set; }
		public int Sequence { get; set; }
		public bool IsRecursive { get; set; }
		public Guid? IdParent { get; set; }

		public List<InspectionQuestionForSummary> ChildSurveyAnswerList { get; set; }
	}
}
