
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
	public class FireSafetyDepartmentValidator : BaseImportWithPictureValidator<ApiClient.DataTransferObjects.FireSafetyDepartment>
	{
		public FireSafetyDepartmentValidator()
		{
			RuleFor(m => m.Language).NotNullOrEmptyWithMaxLength(2);
			RuleFor(m => m.IdCounty).RequiredKeyIsValid();
		}
	}
}
