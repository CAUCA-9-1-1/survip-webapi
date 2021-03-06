﻿using System.Globalization;
using System.Linq;
using System.Text;

namespace Survi.Prevention.ServiceLayer
{
    public static class StringExtensions
    {
	    public static string RemoveDiacritics(this string str)
	    {
		    if (null == str) return null;
		    var chars = str
			    .Normalize(NormalizationForm.FormD)
			    .ToCharArray()
			    .Where(c=> CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
			    .ToArray();

		    return new string(chars).Normalize(NormalizationForm.FormC).ToLower();
	    }
    }
}
