using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests
{
	public class LocalizedBuildingAddressGeneratorTests
	{
		[Theory]
		[InlineData("RUE DES PEUPLIERS", "100", "", "100, RUE DES PEUPLIERS")]
		[InlineData("RUE DES PEUPLIERS", "100", "B", "100B, RUE DES PEUPLIERS")]
		public void AddressIsCorrectlyGenerated(string laneName, string civicNumber, string civicLetter, string result)
		{
			Assert.Equal(result, new AddressGenerator().GenerateAddress(civicNumber, civicLetter, laneName));
		}
	}
}