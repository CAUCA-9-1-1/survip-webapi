using System.Collections.Generic;

namespace Survi.Prevention.ServiceLayer.Tests.Import
{
    public abstract class BaseImportValidatorMethodTests
    {
	    public static IEnumerable<object[]> GetMaxLengthString(int length)
	    {
		    return new List<object[]>{new object[] {new string('T',length)}};
	    }
    }
}
