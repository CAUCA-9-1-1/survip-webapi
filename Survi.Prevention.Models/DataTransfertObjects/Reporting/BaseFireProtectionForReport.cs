namespace Survi.Prevention.Models.DataTransfertObjects.Reporting
{
    public abstract class BaseFireProtectionForReport
    {
        public string Floor { get; set; }
        public string Wall { get; set; }
        public string Sector { get; set; }
        public string TypeName { get; set; }
    }
}