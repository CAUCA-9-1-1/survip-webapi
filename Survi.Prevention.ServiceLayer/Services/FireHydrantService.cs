using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantService : BaseCrudService<FireHydrant>
    {
        public FireHydrantService(ManagementContext context) : base(context)
        {
        }

        public override FireHydrant Get(Guid id)
        {
            var result = Context.FireHydrants
                        .First(s => s.Id == id);

            return result;
        }

        public override List<FireHydrant> GetList()
        {
            var result = Context.FireHydrants
                        .ToList();

            return result;
        }
    }
}
