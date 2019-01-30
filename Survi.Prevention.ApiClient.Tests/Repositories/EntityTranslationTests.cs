using NUnit.Framework;
using Survi.Prevention.ApiClient.Localization;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
	[TestFixture]
    public class EntityTranslationTests
    {
        [TestCase]
        public static void EntityIsValid()
        {
            Assert.AreEqual("Bâtiment",new EntityTranslator().TranslateEntity("Building"));
        }

        [TestCase]
        public static void EntityIsNotValid()
        {
            Assert.AreNotEqual("Bâtiment", new EntityTranslator().TranslateEntity("Builddding"));
        }
    }
}
