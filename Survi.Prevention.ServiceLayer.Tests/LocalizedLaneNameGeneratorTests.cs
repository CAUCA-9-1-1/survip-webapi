using System;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests
{
	public class LocalizedLaneNameGeneratorTests
	{
		[Theory]
		[InlineData("Peupliers", "des", "rue", true, "rue des Peupliers")]
		[InlineData("Dionne", "", "Boulevard", true, "Boulevard Dionne")]
		[InlineData("eau", "de l'", "rue", false, "rue de l'eau")]
		[InlineData("Fraser", "", "", true, "Fraser")]
		public void LocalizedLaneNameAreCorrectlyGenerated(string name, string genericDescription, string publicDescription, bool addWhiteSpaceAfterGeneric, string result)
		{
			Assert.Equal(result, new LocalizedLaneNameGenerator().GenerateLaneName(name, genericDescription, publicDescription, addWhiteSpaceAfterGeneric));
		}
	}
}