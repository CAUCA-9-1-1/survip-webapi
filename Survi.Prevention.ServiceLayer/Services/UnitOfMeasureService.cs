using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class UnitOfMeasureService : BaseCrudService<UnitOfMeasure>
    {
        public UnitOfMeasureService(ManagementContext context) : base(context)
        {
        }

        public override UnitOfMeasure Get(Guid id)
        {
            var result = Context.UnitOfMeasures
                        .Include(s => s.Localizations)
                        .First(s => s.Id == id);

            return result;
        }

        public override List<UnitOfMeasure> GetList()
        {
            var result = Context.UnitOfMeasures
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }
    }
}
