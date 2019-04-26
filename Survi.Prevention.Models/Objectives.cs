using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.DataLayer
{
    public class Objectives : BaseModel
    {
        public Guid IdFireSafetyDepartment { get; set; }
        public int Year { get; set; }
        public int Objective { get; set; }
        public bool IsHighRisk { get; set; } = false;
    }
}
