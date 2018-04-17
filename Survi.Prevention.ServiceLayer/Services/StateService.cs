using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class StateService : BaseService
    {
        public StateService(ManagementContext context) : base(context)
        {
        }

        public State Get(Guid id)
        {
            var result = Context.States
                        .Include(s => s.Localizations)
                        .First(s => s.Id == id);

            return result;
        }

        public List<State> GetList()
        {
            var result = Context.States
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }

        public Boolean AddOrUpdate(State state)
        {
            var isExistRecord = Context.States.Any(s => s.Id == state.Id);

            if (isExistRecord)
            {
                Context.States.Update(state);
            }
            else
            {
                Context.States.Add(state);
            }
            
            Context.SaveChanges();

            return true;
        }

        public Boolean Remove(Guid id)
        {
            var state = Context.States.Find(id);

            state.IsActive = false;
            Context.SaveChanges();

            return true;
        }
    }
}
