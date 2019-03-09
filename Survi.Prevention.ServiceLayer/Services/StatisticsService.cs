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
    public class StatisticsService : BaseService
    {
        public StatisticsService(IManagementContext context) : base(context)
        {
        }

        public List<InspectionForStatistics> GetStatistics()
        {
            var query =
                           from inspection in Context.Inspections
                           where inspection.IsActive
                                 && (inspection.Status == InspectionStatus.Todo || inspection.Status == InspectionStatus.Started ||
                                     inspection.Status == InspectionStatus.Refused)
                           let building = inspection.MainBuilding
                           select new
                           {
                               inspection.Id,
                               inspection.Status,
                               date  = (
                                   Context.InspectionVisits
                                       .Where(visit => visit.IdInspection == inspection.Id)
                                       .OrderBy(visit => visit.EndedOn)
                                       .Where(iv => iv.IsActive && iv.Status == InspectionVisitStatus.Completed)
                                       .Select(visit => visit.EndedOn)
                                       .LastOrDefault()),
                              approbationRefusalReason = (
                                   Context.InspectionVisits
                                       .Where(visit => visit.IdInspection == inspection.Id)
                                       .OrderBy(visit => visit.EndedOn)
                                       .Where(iv => iv.IsActive && iv.Status == InspectionVisitStatus.Completed)
                                       .Select(visit => visit.ReasonForApprobationRefusal)
                                       .LastOrDefault())
                           };

            var results = query.AsNoTracking().ToList()
                .Select(result => new InspectionForStatistics
                {
                    Id = result.Id,
                    Status = result.Status,
                    ApprobationRefusalReason = result.approbationRefusalReason ?? "",
                    InspectionOn = result.date ?? null,
                });

            return results.ToList();
        }

    }
}
