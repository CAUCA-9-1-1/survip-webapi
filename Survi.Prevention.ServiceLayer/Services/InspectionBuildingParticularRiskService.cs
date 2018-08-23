using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingParticularRiskService : BaseService
	{
		public InspectionBuildingParticularRiskService(ManagementContext context) : base(context)
		{
		}

		public InspectionBuildingParticularRisk Get<T>(Guid idBuilding) where T: InspectionBuildingParticularRisk, new()
		{
			var entity = Context.InspectionBuildingParticularRisks.AsNoTracking()
				.OfType<T>()
				.FirstOrDefault(risk => risk.IdBuilding == idBuilding && risk.IsActive)
				?? CreateMissingParticularRisk<T>(idBuilding);
			return entity;
		}

		private T CreateMissingParticularRisk<T>(Guid idBuilding) where T : InspectionBuildingParticularRisk, new()
		{
			var entity = new T {IdBuilding = idBuilding};
			Context.Add(entity);
			Context.SaveChanges();
			return entity;
		}

		public virtual Guid AddOrUpdate<T>(T entity) where T: InspectionBuildingParticularRisk
		{
			var isExistRecord = Context.InspectionBuildingParticularRisks.Any(c => c.Id == entity.Id);

			if (isExistRecord)
				Context.InspectionBuildingParticularRisks.Update(entity);
			else
				Context.InspectionBuildingParticularRisks.Add(entity);

			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove<T>(Guid id)
		{
			var entity = Context.InspectionBuildingParticularRisks.Find(id);
			entity.IsActive = false;
			Context.SaveChanges();

			return true;
		}
	}
}
