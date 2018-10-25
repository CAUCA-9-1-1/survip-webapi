using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

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
						.Where(uom => uom.IsActive)
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }

		public List<GenericModelForDisplay> GetListLocalized(string languageCode, MeasureType type)
		{
			var query =
				from unit in Context.UnitOfMeasures.AsNoTracking()
				where unit.IsActive && unit.MeasureType == type
				from loc in unit.Localizations
				where loc.LanguageCode == languageCode
				select new GenericModelForDisplay {Id = unit.Id, Name = loc.Name};

			return query.ToList();
		}
    }
}
