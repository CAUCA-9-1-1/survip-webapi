using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Lane;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using ImportedCode = Survi.Prevention.ApiClient.DataTransferObjects.LaneGenericCode;

namespace Survi.Prevention.ServiceLayer.Tests.Import.LaneImportation
{
    public class LaneGenericCodeImportTests
    {
	    private readonly ImportedCode importedLaneGenericCode;

	    public LaneGenericCodeImportTests()
	    {
		    importedLaneGenericCode = new ImportedCode
		    {
			    Id = "FireSafetyDepartment",
			    Code = "1",
			    Description = "GenericCode",
				AddWhiteSpaceAfter = false,
			    IsActive = true
		    };
	    }

	    private IManagementContext CreateMockContext()
	    {
		    var mockCtx = new BaseContextMock();
		    mockCtx.Setup(ctx => ctx.Set<LaneGenericCode>()).Returns(mockCtx.GetMockDbSet(new List<LaneGenericCode>()).Object);

		    return mockCtx.Object;
	    }

	    [Fact]
	    public void CustomFieldsAreCorrectlyCopied()
	    {
		    var validator = new LaneGenericCodeValidator();
		    var converter = new LaneGenericCodeImportationConverter(CreateMockContext(), validator, new CacheSystem());
		    var result = converter.Convert(importedLaneGenericCode).Result;

		    Assert.True(result.Code == importedLaneGenericCode.Code && 
		                result.Description == importedLaneGenericCode.Description && 
		                result.AddWhiteSpaceAfter == importedLaneGenericCode.AddWhiteSpaceAfter);
	    }
    }
}
