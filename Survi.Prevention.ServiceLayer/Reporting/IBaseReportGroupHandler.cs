using System;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public interface IBaseReportGroupHandler
	{
		string FillGroup(string template, Guid idParent, string languageCode);
	}
}