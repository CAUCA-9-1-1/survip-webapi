using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class LimitedItemList<T>
        where T: class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}

