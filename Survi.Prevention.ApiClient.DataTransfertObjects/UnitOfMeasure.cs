using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class UnitOfMeasure : BaseLocalizableTransferObject
    {
        public string Abbreviation { get; set; }
        public MeasureType MeasureType { get; set; }
    }
}