﻿using System.Collections.Generic;

namespace Survi.Prevention.ApiClient.DataTransferObjects.Base
{
    public abstract class BaseLocalizableTransferObject : BaseTransferObject
    {
        public ICollection<Localization> Localizations { get; set; }
    }

    public abstract class BaseLocalizableTransferObjectWithPicture: BaseTransferObjectWithPicture
    {
        public ICollection<Localization> Localizations { get; set; }
    }
}
