using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingParticularRiskService : BaseService
	{
		public InspectionBuildingParticularRiskService(ManagementContext context) : base(context)
		{
		}

		public BuildingParticularRisk Get<T>(Guid id) where T: BuildingParticularRisk
		{
			return Context.BuildingParticularRisks.AsNoTracking()
				.OfType<T>()
				.FirstOrDefault(risk => risk.Id == id);
		}

		public virtual Guid AddOrUpdate<T>(T entity) where T: BuildingParticularRisk
		{
			var isExistRecord = Context.BuildingParticularRisks.Any(c => c.Id == entity.Id);

			if (isExistRecord)
				Context.BuildingParticularRisks.Update(entity);
			else
				Context.BuildingParticularRisks.Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove<T>(Guid id)
		{
			var entity = Context.BuildingParticularRisks.Find(id);
			entity.IsActive = false;
			Context.SaveChanges();

			return true;
		}
	}
}
