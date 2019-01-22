using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment;
using Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment.CustomFieldsCopier;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using imported = Survi.Prevention.ApiClient.DataTransferObjects;
using fireSafetyDepartment = Survi.Prevention.Models.FireSafetyDepartments.FireSafetyDepartment;

namespace Survi.Prevention.ServiceLayer.Tests.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentImportTests
    {
		private readonly imported.FireSafetyDepartment importedFireSafetyDepartment;

        public FireSafetyDepartmentImportTests()
		{
			importedFireSafetyDepartment = new imported.FireSafetyDepartment()
			{
				Id = "FireSafetyDepartment",
				Language = "fr",
				IdCounty = "CAUCA21092005-10",
				IsActive = true,
                PictureData = new byte[100],
                MimeType = "jpeg",
                Localizations = new List<imported.Base.Localization>
				{
					new imported.Base.Localization{Name = "FireSafetyDepartment 1", LanguageCode = "en"},
					new imported.Base.Localization{Name = "SSI 1", LanguageCode = "fr"}
				}
			};
        }

	    private IManagementContext CreateMockContext()
	    {
	        var counties = new List<County> { new County{IdExtern = "CAUCA21092005-10"} };
	        var mockCtx = new BaseContextMock();
	        mockCtx.Setup(ctx => ctx.Set<County>()).Returns(mockCtx.GetMockDbSet(counties).Object);
		    mockCtx.Setup(ctx => ctx.Set<fireSafetyDepartment>()).Returns(mockCtx.GetMockDbSet(new List<fireSafetyDepartment>()).Object);

            return mockCtx.Object;
	    }

	    [Fact]
	    public void CustomFieldsAreCorrectlyCopied()
	    {
	        var validator = new FireSafetyDepartmentValidator();
	        var converter = new FireSafetyDepartmentImportationConverter(CreateMockContext(), validator, new FireSafetyDepartmentCustomFieldsCopier(), new CacheSystem());
	        var result = converter.Convert(importedFireSafetyDepartment).Result;

	        Assert.True(result.Language == importedFireSafetyDepartment.Language);
	    }
    }
}
