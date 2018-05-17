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

		public BuildingParticularRisk Get<T>(Guid idBuilding) where T: BuildingParticularRisk, new()
		{
			var entity = Context.BuildingParticularRisks.AsNoTracking()
				.OfType<T>()
				.FirstOrDefault(risk => risk.IdBuilding == idBuilding && risk.IsActive)
				?? CreateMissingParticularRisk<T>(idBuilding);
			return entity;
		}

		private T CreateMissingParticularRisk<T>(Guid idBuilding) where T : BuildingParticularRisk, new()
		{
			var entity = new T {IdBuilding = idBuilding};
			Context.Add(entity);
			Context.SaveChanges();
			return entity;
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
