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



            return results.ToList();
        }

    }
}
