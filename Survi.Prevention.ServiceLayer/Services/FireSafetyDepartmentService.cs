using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using importedFireDeptCityServing = Survi.Prevention.ApiClient.DataTransferObjects.FireSafetyDepartmentCityServing;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FireSafetyDepartmentService : BaseCrudServiceWithImportation<FireSafetyDepartment, ApiClient.DataTransferObjects.FireSafetyDepartment>
	{
		private readonly IEntityConverter<importedFireDeptCityServing, FireSafetyDepartmentCityServing> cityServingConverter;

		public FireSafetyDepartmentService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.FireSafetyDepartment, FireSafetyDepartment> converter,
			IEntityConverter<importedFireDeptCityServing, FireSafetyDepartmentCityServing> servingConverter)
			: base(context, converter)
		{
			cityServingConverter = servingConverter;
		}

		public override FireSafetyDepartment Get(Guid id)
		{
			var result = Context.FireSafetyDepartments
				.Include(s => s.Localizations)
				.First(s => s.Id == id);

			return result;
		}

		public List<FireSafetyDepartmentLocalized> GetLocalized(string languageCode, List<Guid> allowedDepartmentIds = null)
		{
			var query = 
				from department in Context.FireSafetyDepartments.AsNoTracking()
				where department.IsActive
				select department;

			if (allowedDepartmentIds != null)
				query = query.Where(department => allowedDepartmentIds.Contains(department.Id));

			var queryFinal = 
				from department in query
				from localization in department.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				orderby localization.Name
				select new FireSafetyDepartmentLocalized
				{
					Id = department.Id,
					Name = localization.Name
				};

			return queryFinal.ToList();
		}

		public override List<FireSafetyDepartment> GetList()
		{
			var result = Context.FireSafetyDepartments
				.Where(fsd => fsd.IsActive)
                .Include(s => s.Localizations)
				.ToList();

			return result;
		}

		public List<GenericModelForDisplay> GetListLocalized(string languageCode, List<Guid> fireSafetyDepartmentIds)
		{
			var result =
				from department in Context.FireSafetyDepartments.AsNoTracking()
				where department.IsActive && fireSafetyDepartmentIds.Contains(department.Id)
				from localization in department.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode
				
				select new GenericModelForDisplay { Id = department.Id, Name = localization.Name};

			return result.Distinct().ToList();
		}

		public List<ImportationResult> ImportFireSafetyDepartmentCityServings(List<importedFireDeptCityServing> entities)
		{
		    Context.IsInImportationMode = true;
			var resultList = new List<ImportationResult>();
			foreach (var entity in entities)
				resultList.Add(ImportFireSafetyDepartmentCityServing(entity));

			return resultList;
		}

		protected ImportationResult ImportFireSafetyDepartmentCityServing(importedFireDeptCityServing importedEntity)
		{
			var result = GetImportationResult(importedEntity);

			if (result.IsValid)
			{
				Context.SaveChanges();
				result.HasBeenImported = true;
			}
			return result;
		}

		protected ImportationResult GetImportationResult(importedFireDeptCityServing importedEntity)
		{
			var conversionResult = cityServingConverter.Convert(importedEntity);
			return new ImportationResult
			{
				IdEntity = importedEntity.Id,
				Messages = conversionResult.ValidationErrors
			};
		}

        public override Guid AddOrUpdate(FireSafetyDepartment firesafetydepartment)
        {
            if (firesafetydepartment.Picture != null)
            {
                firesafetydepartment.IdPicture = UpdatePicture(firesafetydepartment);
            }

            return base.AddOrUpdate(firesafetydepartment);
        }

        private Guid UpdatePicture(FireSafetyDepartment firesafetydepartment)
        {
            var isExistRecord = Context.Pictures.Any(p => p.Id == firesafetydepartment.Picture.Id);

            if (!isExistRecord)
                Context.Add(firesafetydepartment.Picture);
            else
                firesafetydepartment.Picture.LastModifiedOn = DateTime.Now;

            Context.SaveChanges();

            return firesafetydepartment.Picture.Id;
        }
    }
}