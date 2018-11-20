﻿using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public interface IEntityConverter<in TIn, TOut>
        where TIn: BaseTransferObject
        where TOut: new()
    {
        ConversionResult<TOut> Convert(TIn entity);
    }
}