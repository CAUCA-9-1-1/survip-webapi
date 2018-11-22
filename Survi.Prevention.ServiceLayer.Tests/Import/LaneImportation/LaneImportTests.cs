using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using imported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Lane;

namespace Survi.Prevention.ServiceLayer.Tests.Import.LaneImportation
{
    public class LaneImportTests
    {
	    private readonly imported.Lane importedLane;

	    public LaneImportTests()
	    {
		    importedLane = new imported.Lane()
		    {
			    Id = "Id",
			    IdCity = "IdCity",
			    IdLaneGenericCode = "IdLaneGenericCode",
			    IdPublicCode = "IdPublicCode",
				IsValid = true,
			    IsActive = true,                
			    Localizations = new List<imported.Base.Localization>
			    {
				    new imported.Base.Localization{Name = "Lane 1", LanguageCode = "en"},
				    new imported.Base.Localization{Name = "Rue 1", LanguageCode = "fr"}
			    }
		    };
	    }

	    private IManagementContext CreateMockContext()
	    {
		    var lanes = new List<Lane> { new Lane{IdExtern = "Id"} };
		    var cities = new List<City> { new City{IdExtern = "IdCity"} };
		    var genericCodes = new List<LaneGenericCode> { new LaneGenericCode{IdExtern = "IdLaneGenericCode"} };
		    var publicCodes = new List<LanePublicCode> { new LanePublicCode{IdExtern = "IdPublicCode"} };
		    var mockCtx = new BaseContextMock();
		    mockCtx.Setup(ctx => ctx.Set<Lane>()).Returns(mockCtx.GetMockDbSet(lanes).Object);
		    mockCtx.Setup(ctx => ctx.Set<LaneGenericCode>()).Returns(mockCtx.GetMockDbSet(genericCodes).Object);
		    mockCtx.Setup(ctx => ctx.Set<City>()).Returns(mockCtx.GetMockDbSet(cities).Object);
		    mockCtx.Setup(ctx => ctx.Set<LanePublicCode>()).Returns(mockCtx.GetMockDbSet(publicCodes).Object);

		    return mockCtx.Object;
	    }

	    [Fact]
	    public void CustomFieldsAreCorrectlyCopied()
	    {
		    var validator = new LaneValidator();
		    var converter = new LaneImportationConverter(CreateMockContext(), validator);
		    var result = converter.Convert(importedLane).Result;

		    Assert.True(result.IsValid == importedLane.IsValid);
	    }
    }
}
