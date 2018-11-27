using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.DataLayer;
using ImportedPublicCode = Survi.Prevention.ApiClient.DataTransferObjects.LanePublicCode;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LanePublicCodeService : BaseService
	{
		private readonly IEntityConverter<ImportedPublicCode, LanePublicCode> publicLaneCodeConverter;
		public LanePublicCodeService(IManagementContext context,
			IEntityConverter<ImportedPublicCode, LanePublicCode> converter) : base(context)
		{
			publicLaneCodeConverter = converter;
		}

		public List<LanePublicCode> GetList()
		{
			var result = Context.LanePublicCodes.ToList();

			return result;
		}

		public List<ImportationResult> ImportLanePublicCodes(List<ImportedPublicCode> importedLanePublicCodes)
		{
			var resultList = new List<ImportationResult>();
			foreach (var code in importedLanePublicCodes)
				resultList.Add(ImportPublicCode(code));

			return resultList;
		}

		protected ImportationResult ImportPublicCode(ImportedPublicCode importedLanePublicCode)
		{
			var result = GetImportationResult(importedLanePublicCode);

			if (result.IsValid)
			{
				Context.SaveChanges();
				result.HasBeenImported = true;
			}
			return result;
		}

		protected ImportationResult GetImportationResult(ImportedPublicCode importedLanePublicCode)
		{
			var conversionResult = publicLaneCodeConverter.Convert(importedLanePublicCode);
			return new ImportationResult
			{
				IdEntity = importedLanePublicCode.Id,
				Messages = conversionResult.ValidationErrors
			};
		}
	}
}