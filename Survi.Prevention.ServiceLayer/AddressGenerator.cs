using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using System;
using System.Linq;

namespace Survi.Prevention.ServiceLayer
{
    public class AddressGenerator
    {
		public string GenerateAddress(string civicNumber, string civicLetter, string laneName, string genericDescription, string publicDescription, bool addWhiteSpaceAfterGeneric)
		{
			var lane = new LocalizedLaneNameGenerator().GenerateLaneName(laneName, genericDescription, publicDescription, addWhiteSpaceAfterGeneric);
			return GenerateAddress(civicNumber, civicLetter, lane);
		}

	    public string GenerateAddress(string civicNumber, string civicLetter, string localizedLaneName)
	    {
		    return $"{civicNumber}{civicLetter}, {localizedLaneName}";
	    }
	}
}
