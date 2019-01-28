﻿using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionForExport
    {
        public Guid Id { get; set; }
        public Guid IdBuilding { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
