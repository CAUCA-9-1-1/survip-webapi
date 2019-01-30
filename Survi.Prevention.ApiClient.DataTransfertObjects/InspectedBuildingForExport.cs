﻿using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using System;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
   public class InspectedBuidldingForExport: BaseTransferObject
    {
        public Guid IdBuilding { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
