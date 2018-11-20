using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public class ConversionResult<T>
    {
        public T Result { get; set; }
        public bool IsValid => !(ValidationErrors?.Any() ?? false);
        public List<string> ValidationErrors { get; set; }
    }
}