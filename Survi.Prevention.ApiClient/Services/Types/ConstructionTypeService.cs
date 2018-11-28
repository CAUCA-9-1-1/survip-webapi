﻿using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class ConstructionTypeService : BaseSecureService<ConstructionType>
	{
		protected override string BaseUrl { get; set; } = "Construction/ConstructionType/Import";
	}    
}
