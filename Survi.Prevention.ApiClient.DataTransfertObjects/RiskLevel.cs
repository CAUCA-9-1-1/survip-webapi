using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class RiskLevel : BaseLocalizableTransferObject
    {
        public int Sequence { get; set; }
        public int Code { get; set; }
        public string ArgbColor { get; set; }
    }
}