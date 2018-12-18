using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Lane;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedCode = Survi.Prevention.ApiClient.DataTransferObjects.LanePublicCode;

namespace Survi.Prevention.ServiceLayer.Tests.Import.LaneImportation
{
    public class LanePublicCodeImportTests
    {
	    private readonly ImportedCode importedLanePublicCode;

	    public LanePublicCodeImportTests()
	    {
		    importedLanePublicCode = new ImportedCode
		    {
			    Id = "FireSafetyDepartment",
			    Code = "02",
			    Description = "CAUCA21092005-10",
			    Abbreviation = "2",
			    IsActive = true
		    };
	    }

	    private IManagementContext CreateMockContext()
	    {
		    var mockCtx = new BaseContextMock();
		    mockCtx.Setup(ctx => ctx.Set<LanePublicCode>()).Returns(mockCtx.GetMockDbSet(new List<LanePublicCode>()).Object);

		    return mockCtx.Object;
	    }

	    [Fact]
	    public void CustomFieldsAreCorrectlyCopied()
	    {
		    var validator = new LanePublicCodeValidator();
		    var converter = new LanePublicCodeImportationConverter(CreateMockContext(), validator, new CacheSystem());
		    var result = converter.Convert(importedLanePublicCode).Result;

		    Assert.True(result.Code == importedLanePublicCode.Code && 
		                result.Description == importedLanePublicCode.Description && 
		                result.Abbreviation == importedLanePublicCode.Abbreviation);
	    }
    }
}
