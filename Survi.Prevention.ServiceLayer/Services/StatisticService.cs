using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class StatisticService : BaseService
    {
        public StatisticService(IManagementContext context) : base(context)
        {
        }

        public List<Objectives> GetObjectiveList(bool isHighRisk)
        {
            var result = Context.Objectives
                .Where(r => r.IsActive && r.IsHighRisk == isHighRisk)
                .Include(r => r.FireSafetyDepartment)
                .OrderBy(r => r.Year)
                .ToList();

            return result;
        }

        public List<Objectives> GetList(Guid idFireSafetyDepartment)
        {
            var result = Context.Objectives
                .Where(r => r.IsActive && r.IdFireSafetyDepartment == idFireSafetyDepartment)
                .Include(r => r.FireSafetyDepartment)
                .OrderBy(r => r.Year)
                .ToList();

            return result;
        }

        public Guid Save(Objectives objective)
        {
            AddOrUpdate(objective);

            return objective.Id;
        }

        public bool Remove(Guid id)
        {
            var entity = Context.Set<Objectives>().Find(id);

            if (entity == null)
                return false;

            entity.IsActive = false;
            Context.SaveChanges();
            return true;
        }

        private void AddOrUpdate(Objectives objective)
        {
            var isExistRecord = Context.Objectives.Any(c => c.Id == objective.Id);

            if (isExistRecord)
                Context.Objectives.Update(objective);
            else
                Context.Objectives.Add(objective);

            Context.SaveChanges();
        }

        public List<InspectionVisitForStatistics> GetInspectionVisitStatistics(List<Guid> idCities)
        {
            var query =
               from visit in Context.InspectionVisits
               where visit.IsActive
                     && idCities.Contains(visit.Inspection.MainBuilding.IdCity)
               let building = visit.Inspection.MainBuilding
               from fireSafetyDeparmentCityServing in Context.FireSafetyDepartmentCityServings
               where fireSafetyDeparmentCityServing.IsActive
                    && fireSafetyDeparmentCityServing.IdCity == building.IdCity
               select new
               {
                   visit.Id,
                   building.IdCity,
                   fireSafetyDeparmentCityServing.IdFireSafetyDepartment,
                   visit.Status,
                   visit.EndedOn,
                   building.RiskLevel.Code,
                   visit.HasBeenRefused,
                   visit.OwnerWasAbsent,
                   visit.DoorHangerHasBeenLeft,
               };

            return query.AsNoTracking().ToList()
                .Select(result => new InspectionVisitForStatistics
                {
                    Id = result.Id,
                    IdFireSafetyDepartment = result.IdFireSafetyDepartment,
                    Status = result.Status,
                    CompletedOn = result.EndedOn,
                    RiskLevel = result.Code,
                    HasBeenRefused = result.HasBeenRefused,
                    OwnerWasAbsent = result.OwnerWasAbsent,
                    DoorHangerHasBeenLeft = result.DoorHangerHasBeenLeft
                }).ToList();
        }
    }
}
