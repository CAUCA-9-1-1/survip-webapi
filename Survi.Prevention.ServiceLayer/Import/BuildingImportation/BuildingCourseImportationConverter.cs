using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingCourseImportationConverter 
        : BaseEntityConverter<BuildingCourse, Models.Buildings.BuildingCourse>
    {
        public BuildingCourseImportationConverter(
            IManagementContext context, 
            AbstractValidator<BuildingCourse> validator, ICustomFieldsCopier<BuildingCourse, 
                Models.Buildings.BuildingCourse> copier) 
            : base(context, validator, copier)
        {
        }

        protected override Models.Buildings.BuildingCourse GetEntityFromDatabase(string externalId)
        {
            return Context.Set<Models.Buildings.BuildingCourse>()
                .IgnoreQueryFilters()
                .Include(course => course.Lanes)
                .FirstOrDefault(course => course.IdExtern == externalId);
        }

        protected override void GetRealForeignKeys(BuildingCourse importedObject)
        {
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdFirestation = GetRealId<Models.FireSafetyDepartments.Firestation>(importedObject.IdFirestation);
            foreach(var lane in importedObject.Lanes)
                lane.IdLane = GetRealId<Models.FireSafetyDepartments.Lane>(lane.IdLane);
        }
    }
}