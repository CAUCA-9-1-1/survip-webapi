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
    public class ObjectiveService : BaseService
    {
        public ObjectiveService(IManagementContext context) : base(context)
        {
        }

        public List<Objectives> GetList(Guid idFireSafetyDeparment)
        {
            var result = Context.Objectives
                .Where(r => r.IdFireSafetyDepartment == idFireSafetyDeparment)
                .ToList();

            return result;
        }

        public Guid Save(Objectives objective)
        {
            AddOrUpdate(objective);

            return objective.Id;
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

    }
}
