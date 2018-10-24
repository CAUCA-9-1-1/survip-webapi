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

		public InspectionBuildingParticularRisk Get<T>(Guid idBuilding, Guid idWebUserLastModifiedBy) where T : InspectionBuildingParticularRisk, new()
		{
			var entity = Context.InspectionBuildingParticularRisks.AsNoTracking()
				.OfType<T>()
				.FirstOrDefault(risk => risk.IdBuilding == idBuilding && risk.IsActive)
				?? CreateMissingParticularRisk<T>(idBuilding, idWebUserLastModifiedBy);
			return entity;
		}

		private T CreateMissingParticularRisk<T>(Guid idBuilding, Guid idWebUserLastModifiedBy) where T : InspectionBuildingParticularRisk, new()
		{
			var entity = new T { IdBuilding = idBuilding, IdWebUserLastModifiedBy = idWebUserLastModifiedBy };
			Context.Add(entity);
			Context.SaveChanges();
			return entity;
		}

		public virtual Guid AddOrUpdate<T>(T entity, Guid idWebUserLastModifiedBy) where T : InspectionBuildingParticularRisk
		{
			var isExistRecord = Context.InspectionBuildingParticularRisks.Any(c => c.Id == entity.Id);

			if (isExistRecord)
			{
				UpdateInspectionBuildingParticularRiskModifiedInformation(entity, idWebUserLastModifiedBy);
				Context.InspectionBuildingParticularRisks.Update(entity);
			}
			else
			{
				entity.IdWebUserLastModifiedBy = idWebUserLastModifiedBy;
				Context.InspectionBuildingParticularRisks.Add(entity);
			}

			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove<T>(Guid id, Guid idWebUserLastModifiedBy)
		{
			var entity = Context.InspectionBuildingParticularRisks.Find(id);
			UpdateInspectionBuildingParticularRiskModifiedInformation(entity, idWebUserLastModifiedBy);
			entity.IsActive = false;
			Context.SaveChanges();

			return true;
		}

		public void UpdateInspectionBuildingParticularRiskModifiedInformation(InspectionBuildingParticularRisk entity, Guid idWebUserLastModifiedBy)
		{
			entity.IdWebUserLastModifiedBy = idWebUserLastModifiedBy;
			entity.LastModifiedOn = DateTime.Now;
		}

	}
}
