﻿using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class InpectedBuildingReportForExport: BaseTransferObject
    {
        public string IdBuilding { get; set; }
        public byte[] ReportData { get; set; }
    }
}
