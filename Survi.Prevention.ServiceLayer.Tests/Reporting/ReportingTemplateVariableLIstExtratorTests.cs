using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ServiceLayer.Reporting;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Reporting
{
    public class ReportingTemplateVariableLIstExtratorTests
    {
		[Fact]
		public void VariablesAreCorrectlyExtractedWhenAllAreWellFormed()
		{
			var template = "<bold>[BuildingSprinkler]{bla}[/Sprinkler][Detail][/Detail][/Building]</bold>";
			var result = new ReportingTemplateVariableListExtractor(template).GetGroups();
			Assert.Empty(result.Except(new List<ReportBuildingGroup> {ReportBuildingGroup.Building, ReportBuildingGroup.BuildingDetail, ReportBuildingGroup.MainBuildingSprinkler}));
		}

	    [Fact]
	    public void VariablesAreCorrectlyExtractedWhenSomeAreNotWellFormed()
	    {
		    var template = "<bold>[BuildingSprinkler]{bla}[/Sprinkler][Detail][/Building]</bold>";
		    var result = new ReportingTemplateVariableListExtractor(template).GetGroups();
		    Assert.Empty(result.Except(new List<ReportBuildingGroup> { ReportBuildingGroup.Building, ReportBuildingGroup.MainBuildingSprinkler }));
	    }
	}
}
