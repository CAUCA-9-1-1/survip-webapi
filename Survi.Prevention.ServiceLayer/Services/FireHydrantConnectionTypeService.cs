using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantConnectionTypeService : BaseCrudService<FireHydrantConnectionType>
    {
        public FireHydrantConnectionTypeService(ManagementContext context) : base(context)
        {
        }

        public override FireHydrantConnectionType Get(Guid id)
        {
            var result = Context.FireHydrantConnectionTypes
                        .Include(s => s.Localizations)
                        .First(s => s.Id == id);

            return result;
        }

        public override List<FireHydrantConnectionType> GetList()
        {
            var result = Context.FireHydrantConnectionTypes
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }
    }
}
