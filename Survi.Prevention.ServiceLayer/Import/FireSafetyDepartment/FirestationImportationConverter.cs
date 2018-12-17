using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Import.FireSafetyDepartment
{
    public class FirestationImportationConverter 
        : BaseEntityConverter<Firestation, Models.FireSafetyDepartments.Firestation>
    {
        public FirestationImportationConverter(
            IManagementContext context, 
            AbstractValidator<Firestation> validator, 
            ICustomFieldsCopier<Firestation, Models.FireSafetyDepartments.Firestation> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(Firestation importedObject)
        {
            importedObject.IdFireSafetyDepartment = GetRealId<Models.FireSafetyDepartments.FireSafetyDepartment>(importedObject.IdFireSafetyDepartment);
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }
    }
}