using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FireSafetyDepartmentService : BaseCrudService<FireSafetyDepartment>
	{
		public FireSafetyDepartmentService(IManagementContext context) : base(context)
		{
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
	}
}