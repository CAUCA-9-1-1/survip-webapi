using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.DataCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBatchService : BaseCrudService<Batch>
	{
		public InspectionBatchService(ManagementContext context) : base(context)
		{
		}

		public override Batch Get(Guid id)
		{
			var result = Context.Batches
				.Include(b => b.Users)
				.Include(b => b.Inspections)
				.First(s => s.Id == id);

			return result;
		}

		public override List<Batch> GetList()
		{
			var result = Context.Batches
                .Include(b => b.Users)
                .Include(b => b.Inspections)
                .ToList();

			return result;
		}

        public override bool Remove(Guid id)
        {
            var inspections = Context.Inspections
                .Where(i => i.IdBatch == id)
                .ToList();

	        using (var copyManager = new InspectionBuildingDataCopyDeleter(Context))
	        {
		        inspections.ForEach(inspection =>
		        {
			        inspection.IsActive = false;
			        inspection.Status = InspectionStatus.Canceled;
			        // ReSharper disable once AccessToDisposedClosure
			        copyManager.DeleteCopy(inspection.Id);
		        });
	        }

	        Context.SaveChanges();

            return base.Remove(id);
        }

        public override Guid AddOrUpdate(Batch batch)
        {
            UpdateBatchUser(batch);
            UpdateInspection(batch);

            return base.AddOrUpdate(batch);
        }

        private void UpdateInspection(Batch batch)
        {
            var inspections = new List<Inspection>();
            var dbInspections = new List<Inspection>();

            if (batch.Inspections != null)
                inspections = batch.Inspections.Where(i => i.IdBatch == batch.Id).ToList();
            if (Context.Inspections.AsNoTracking().Any(u => u.IdBatch == batch.Id))
                dbInspections = Context.Inspections.AsNoTracking().Where(i => i.IdBatch == batch.Id).ToList();

            RemoveDeleteChildren(dbInspections, inspections);
            AddOrUpdateChildren(inspections);

            Context.SaveChanges();
        }

		private void AddOrUpdateChildren(List<Inspection> inspections)
		{
			inspections.ForEach(child =>
			{
				var isExistRecord = Context.Inspections.Any(c => c.Id == child.Id);

				if (child.IdSurvey is null)
				{
					var building = Context.Buildings
						.Include(b => b.Lane)
						.Single(b => b.Id == child.IdBuilding && b.IsActive);
					var fireSafetyDepartmentId = Context.FireSafetyDepartments
						.Single(d => d.FireSafetyDepartmentServing.Any(c => c.IdCity == building.Lane.IdCity)).Id;

					child.IdSurvey = GetConfiguredSurvey(building.IdRiskLevel, fireSafetyDepartmentId);
				}

				if (!isExistRecord)
				{
					Context.Inspections.Add(child);
				}
			});
		}

		private Guid? GetConfiguredSurvey(Guid idRiskLevel, Guid idFireSafetyDepartment)
		{
			var query =
				from config in Context.FireSafetyDepartmentInspectionConfigurations.AsNoTracking()
				where config.IsActive && config.IdFireSafetyDepartment == idFireSafetyDepartment
				                      && config.RiskLevels.Any(risk => risk.IdRiskLevel == idRiskLevel && risk.IsActive)
				select config.IdSurvey;

			return query.FirstOrDefault();
		}

		private void RemoveDeleteChildren(List<Inspection> dbInspections, List<Inspection> inspections)
		{
			using (var copyManager = new InspectionBuildingDataCopyDeleter(Context))
			{
				dbInspections.ForEach(child =>
				{
					if (inspections.All(i => i.Id != child.Id))
					{
						Context.Inspections.Remove(child);
						// ReSharper disable once AccessToDisposedClosure
						copyManager.DeleteCopy(child.Id);
					}
				});
			}
		}

		private void UpdateBatchUser(Batch batch)
        {
            var users = new List<BatchUser>();
            var dbUsers = new List<BatchUser>();

            if (batch.Users != null)
                users = batch.Users.Where(u => u.IdBatch == batch.Id).ToList();
            if (Context.BatchUsers.AsNoTracking().Any(u => u.IdBatch == batch.Id))
                dbUsers = Context.BatchUsers.AsNoTracking().Where(u => u.IdBatch == batch.Id).ToList();

            RemoveDeletedBatchUsers(dbUsers, users);
            UpdateBatchUsers(users);

            Context.SaveChanges();
        }

		private void UpdateBatchUsers(List<BatchUser> users)
		{
			users.ForEach(child =>
			{
				if (!Context.BatchUsers.Any(c => c.Id == child.Id))
					Context.BatchUsers.Add(child);
			});
		}

		private void RemoveDeletedBatchUsers(List<BatchUser> dbUsers, List<BatchUser> users)
		{
			dbUsers.ForEach(child =>
			{
				if (users.All(u => u.Id != child.Id))
					Context.BatchUsers.Remove(child);
			});
		}
	}
}