using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;
using countyImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Places;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CountyImportTests
    {
		private readonly countyImported.County importedCounty;
		private County existingCounty;
		private CountyImportationConverter service;

		public CountyImportTests()
		{
			importedCounty = new countyImported.County
			{
				Id = "state1",
				IdState = "St1",
				IdRegion = "Re1",
				IsActive = true,
				Localizations = new List<countyImported.Base.Localization>
				{
					new countyImported.Base.Localization{Name = "County 1", LanguageCode = "en"},
					new countyImported.Base.Localization{Name = "Mrc 1", LanguageCode = "fr"}
				}
			};

			existingCounty = new County
			{
				Id = Guid.NewGuid(),
				IdState = Guid.NewGuid(),
				IdRegion = Guid.NewGuid(),
				IsActive = true,
			};
			existingCounty.Localizations = new List<CountyLocalization>
			{
				new CountyLocalization
					{Id = Guid.NewGuid(), Name = "County 1", LanguageCode = "en", IdParent = existingCounty.Id},
				new CountyLocalization
					{Id = Guid.NewGuid(), Name = "Mrc 1", LanguageCode = "fr", IdParent = existingCounty.Id}
			};

			InitiateTestingMock();
		}

	    private void InitiateTestingMock()
	    {
		    var states = InitStateList<State>();
			var regions = InitRegionList<Region>();

		    var mockContext = new BaseContextMock();
		    mockContext.Setup(context => context.States).Returns(mockContext.GetMockDbSet(states).Object);
		    mockContext.Setup(context => context.Set<State>()).Returns(mockContext.GetMockDbSet(states).Object);
		    mockContext.Setup(context => context.Regions).Returns(mockContext.GetMockDbSet(regions).Object);
		    mockContext.Setup(context => context.Set<Region>()).Returns(mockContext.GetMockDbSet(regions).Object);
		    mockContext.Setup(context => context.Set<County>()).Returns(mockContext.GetMockDbSet(new List<County>()).Object);
		    mockContext.Object.Set<County>().Add(existingCounty);

		    service = new CountyImportationConverter(mockContext.Object, new CountyValidator());
	    }


		private List<State> InitStateList<State>()
		{
			return new List<State>();
		}

	    private List<Region> InitRegionList<Region>()
	    {
		    return new List<Region>();
	    }

		[Fact]
		public void CountyRegionDoesNotExists()
		{
			Assert.False(service.GetRealRegionForeignKey(importedCounty));
		}

	    [Fact]
	    public void CountyStateDoesNotExists()
	    {
		    Assert.False(service.GetRealStateForeignKey(importedCounty));
	    }
    }
}
