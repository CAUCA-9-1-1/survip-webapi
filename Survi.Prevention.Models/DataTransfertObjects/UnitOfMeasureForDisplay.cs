using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class UnitOfMeasureForDisplay
    {
        public Guid Id { get; set; }
        public MeasureType MeasureType { get; set; }
        public string Name { get; set; }
    }
}
