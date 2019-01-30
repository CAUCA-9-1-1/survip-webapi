using System.Resources;

namespace Survi.Prevention.ApiClient.Localization
{
    public class EntityTranslator
    {
        public string TranslateEntity(string entityName)
        {
            return GetEntityTranslated(entityName);
        }

        private string GetEntityTranslated(string entityName)
        {
            return new ResourceManager(typeof(EntityLocalization)).GetString(entityName) ?? entityName;
        }
    }
}
