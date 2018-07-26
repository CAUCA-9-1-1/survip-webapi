using System;
using System.Text.RegularExpressions;

namespace Survi.Prevention.ServiceLayer 
{
    public class ReportPlaceholders
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        
        public string ReplacePlaceholders(string template)
        {
            var res = Regex.Replace(template, "{{(.*?)}}", m => GetValue(ref m));
            return res;
        }

        private string GetValue(ref Match m)
        {
            try
            {
                return 
                    GetType()
                    .GetProperty(m.Groups[1].Value)
                    .GetValue(this)
                    .ToString();
            }
            catch (NullReferenceException e)
            {
                return m.Groups[1].Value;
            }
        }
    }
}
