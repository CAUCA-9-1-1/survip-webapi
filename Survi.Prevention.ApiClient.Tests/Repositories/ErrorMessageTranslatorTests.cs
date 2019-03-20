using NUnit.Framework;
using Survi.Prevention.ApiClient.Localization;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class ErrorMessagesTestLanguages
    {
        [TestCase]
        public static void ErrorMessageReturnsRighValuesWithFrenchCurrentCulture()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "Une valeur est manquante." };
            Assert.AreEqual(errorMessage.FieldName, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").FieldName);
        }
    }
}
