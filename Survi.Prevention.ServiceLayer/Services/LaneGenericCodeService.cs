using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;
using importedGenericCode = Survi.Prevention.ApiClient.DataTransferObjects.LaneGenericCode;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class LaneGenericCodeService : BaseService
	{
		private readonly IEntityConverter<importedGenericCode, LaneGenericCode> genericCodeConverter;
		public LaneGenericCodeService(IManagementContext context,
			IEntityConverter<importedGenericCode, LaneGenericCode> converter) : base(context)
		{
			genericCodeConverter = converter;
		}

		public List<LaneGenericCode> GetList()
		{
			var result = Context.LaneGenericCodes.ToList();

			return result;
		}

		public List<ImportationResult> ImportLaneGenericCodes(List<importedGenericCode> importedLaneGenericCode)
		{
			var resultList = new List<ImportationResult>();
			foreach (var code in importedLaneGenericCode)
				resultList.Add(ImportLaneGenericCode(code));

			return resultList;
		}

		protected ImportationResult ImportLaneGenericCode(importedGenericCode importedLaneGenericCode)
		{
			var result = GetImportationResult(importedLaneGenericCode);

			if (result.IsValid)
			{
				Context.SaveChanges();
				result.HasBeenImported = true;
			}
			return result;
		}

		protected ImportationResult GetImportationResult(importedGenericCode importedLaneGenericCode)
		{
			var conversionResult = genericCodeConverter.Convert(importedLaneGenericCode);
			return new ImportationResult
			{
				IdEntity = importedLaneGenericCode.Id,
				Messages = conversionResult.ValidationErrors
			};
		}
	}
}