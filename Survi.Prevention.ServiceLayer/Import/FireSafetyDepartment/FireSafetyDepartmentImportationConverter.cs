using System.Linq;
using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using importedFireSafetyDepartment = Survi.Prevention.ApiClient.DataTransferObjects.FireSafetyDepartment;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
    public class FireSafetyDepartmentImportationConverter : BaseLocalizableEntityWithPictureConverter<importedFireSafetyDepartment, Models.FireSafetyDepartments.FireSafetyDepartment, FireSafetyDepartmentLocalization>
    {
        public FireSafetyDepartmentImportationConverter
        (IManagementContext context,
            AbstractValidator<importedFireSafetyDepartment> validator,
            ICustomFieldsCopier<importedFireSafetyDepartment, Models.FireSafetyDepartments.FireSafetyDepartment> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(importedFireSafetyDepartment importedObject)
        {
            var idCounty = Context.Set<County>()
                .FirstOrDefault(county => county.IdExtern == importedObject.IdCounty)?.Id;
            importedObject.IdCounty = idCounty.HasValue ? idCounty.ToString() : null;
        }
    }
}
