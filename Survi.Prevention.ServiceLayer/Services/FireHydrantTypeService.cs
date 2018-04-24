using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantTypeService : BaseCrudService<FireHydrantType>
    {
        public FireHydrantTypeService(ManagementContext context) : base(context)
        {
        }

        public override FireHydrantType Get(Guid id)
        {
            var result = Context.FireHydrantTypes
                        .Include(s => s.Localizations)
                        .First(s => s.Id == id);

            return result;
        }

        public override List<FireHydrantType> GetList()
        {
            var result = Context.FireHydrantTypes
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }
    }
}
