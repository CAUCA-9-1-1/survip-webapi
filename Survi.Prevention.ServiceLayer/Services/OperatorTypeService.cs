using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class OperatorTypeService : BaseCrudService<OperatorType>
    {
        public OperatorTypeService(ManagementContext context) : base(context)
        {
        }

        public override OperatorType Get(Guid id)
        {
            var result = Context.OperatorTypes
                        .First(s => s.Id == id);

            return result;
        }

        public override List<OperatorType> GetList()
        {
            var result = Context.OperatorTypes
                        .ToList();

            return result;
        }
    }
}
