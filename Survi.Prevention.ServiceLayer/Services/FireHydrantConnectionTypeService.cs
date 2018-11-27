using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantConnectionTypeService : BaseCrudServiceWithImportation<FireHydrantConnectionType, ApiClient.DataTransferObjects.FireHydrantConnectionType>
    {
        public FireHydrantConnectionTypeService(
            IManagementContext context, 
            IEntityConverter<ApiClient.DataTransferObjects.FireHydrantConnectionType, FireHydrantConnectionType> converter) 
            : base(context, converter)
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
						.Where(fct => fct.IsActive)
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }
    }
}
