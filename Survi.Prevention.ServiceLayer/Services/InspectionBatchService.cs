using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;

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

            inspections.ForEach(inspection =>
            {
                inspection.IsActive = false;
                inspection.Status = InspectionStatus.Canceled;
            });

            Context.SaveChanges();

            return base.Remove(id);
        }

        public override Guid AddOrUpdate(Batch batch)
        {
            updateBatchUser(batch);
            updateInspection(batch);

            return base.AddOrUpdate(batch);
        }

        private void updateInspection(Batch batch)
        {
            var inspections = new List<Inspection>();
            var dbInspections = new List<Inspection>();

            if (batch.Inspections != null)
                inspections = batch.Inspections.Where(i => i.IdBatch == batch.Id).ToList();
            if (Context.Inspections.AsNoTracking().Any(u => u.IdBatch == batch.Id))
                dbInspections = Context.Inspections.AsNoTracking().Where(i => i.IdBatch == batch.Id).ToList();

            dbInspections.ForEach(child =>
            {
                if (!inspections.Any(i => i.Id == child.Id))
                {
                    Context.Inspections.Remove(child);
                }
            });
            inspections.ForEach(child =>
            {
                var isExistRecord = Context.Inspections.Any(c => c.Id == child.Id);

                if (child.IdSurvey is null)
                {
                    var building = Context.Buildings
                        .Include(b => b.Lane)
                        .Single(b => b.Id == child.IdBuilding && b.IsActive);
                    var idSSI = Context.FireSafetyDepartments
                        .Single(d => d.FireSafetyDepartmentServing.Any(c => c.IdCity == building.Lane.IdCity)).Id;

                    child.IdSurvey = Context.FireSafetyDepartmentRiskLevels.Where(c => c.IdRiskLevel == building.IdRiskLevel && c.IdFireSafetyDepartment == idSSI).Single().IdSurvey;
                }

                if (!isExistRecord)
                {
                    Context.Inspections.Add(child);
                }
            });

            Context.SaveChanges();
        }


        private void updateBatchUser(Batch batch)
        {
            var users = new List<BatchUser>();
            var dbUsers = new List<BatchUser>();

            if (batch.Users != null)
                users = batch.Users.Where(u => u.IdBatch == batch.Id).ToList();
            if (Context.BatchUsers.AsNoTracking().Any(u => u.IdBatch == batch.Id))
                dbUsers = Context.BatchUsers.AsNoTracking().Where(u => u.IdBatch == batch.Id).ToList();

            dbUsers.ForEach(child =>
            {
                if (!users.Any(u => u.Id == child.Id))
                {
                    Context.BatchUsers.Remove(child);
                }
            });
            users.ForEach(child =>
            {
                var isExistRecord = Context.BatchUsers.Any(c => c.Id == child.Id);

                if (!isExistRecord)
                {
                    Context.BatchUsers.Add(child);
                }
            });

            Context.SaveChanges();
        }
	}
}