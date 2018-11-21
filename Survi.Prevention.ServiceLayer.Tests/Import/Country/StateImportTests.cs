using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Country;
using stateImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
	public class StateImportTests
	{
		private readonly stateImported.State importedState;
		private readonly State existingState;
	    private readonly Models.FireSafetyDepartments.Country existingCountry;

        public StateImportTests()
		{
			importedState = new stateImported.State
			{
				Id = "state1",
				AnsiCode = "CO",
				IdCountry = "Country001",
				IsActive = true,                
				Localizations = new List<stateImported.Base.Localization>
				{
					new stateImported.Base.Localization{Name = "State 1", LanguageCode = "en"},
					new stateImported.Base.Localization{Name = "Province 1", LanguageCode = "fr"}
				}
			};

		    existingCountry = new Models.FireSafetyDepartments.Country
		    {
		        Id = Guid.NewGuid(),
		        CodeAlpha2 = "BO",
		        CodeAlpha3 = "BO3",
		        IsActive = true,
                IdExtern = "Country001"
		    };

            existingState = new State
			{
				Id = Guid.NewGuid(),
                IdExtern = "state1",
				AnsiCode = "CB",
				IdCountry = existingCountry.Id,
				IsActive = true,
			};
			existingState.Localizations = new List<StateLocalization>
			{
				new StateLocalization
					{Id = Guid.NewGuid(), Name = "Old State 1", LanguageCode = "en", IdParent = existingState.Id},
				new StateLocalization
					{Id = Guid.NewGuid(), Name = "Old Province 1", LanguageCode = "fr", IdParent = existingState.Id}
			};		    
		    existingCountry.Localizations = new List<CountryLocalization>
		    {
		        new CountryLocalization
		            {Id = Guid.NewGuid(), LanguageCode = "en", Name = "existing Name", IdParent = existingCountry.Id},
		        new CountryLocalization
		            {Id = Guid.NewGuid(), LanguageCode = "fr", Name = "existing Name", IdParent = existingCountry.Id}
		    };
        }

	    private IManagementContext CreateMockContext()
	    {
	        var countries = new List<Models.FireSafetyDepartments.Country> { existingCountry };
	        var states = new List<Models.FireSafetyDepartments.State> {existingState};
	        var mockCtx = new BaseContextMock();
	        mockCtx.Setup(ctx => ctx.Set<Models.FireSafetyDepartments.Country>()).Returns(mockCtx.GetMockDbSet(countries).Object);
	        mockCtx.Setup(ctx => ctx.Set<Models.FireSafetyDepartments.State>()).Returns(mockCtx.GetMockDbSet(states).Object);
            return mockCtx.Object;
	    }

	    [Fact]
	    public void CustomFieldsAreCorrectlyCopied()
	    {
	        var validator = new StateValidator();
	        var converter = new StateImportationConverter(CreateMockContext(), validator);
	        var result = converter.Convert(importedState).Result;

	        Assert.True(result.AnsiCode == importedState.AnsiCode);
	    }
    }
}
