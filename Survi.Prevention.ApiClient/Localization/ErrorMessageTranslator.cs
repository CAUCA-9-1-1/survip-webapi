using System.Collections.Generic;
using System.Resources;

namespace Survi.Prevention.ApiClient.Localization
{
    public class ErrorMessageTranslator
    {
        //aller chercher la translation dans les fichier de ressources
        private string errorMessage;
        private string[] errorMessageList;

        public List<ErrorMessageInformation> TranslateErrorMessages(List<string> errors)
        {
            var errorList = new List<ErrorMessageInformation>();
            foreach (var error in errors)
            {
                errorList.Add(GetErrorMessageTranslated(error));
            }
            return errorList;
        }

        public ErrorMessageInformation GetErrorMessageTranslated(string errorMessage)
        {
            this.errorMessage = errorMessage;
            SplitErrorMessage();
            return CreateErrorMessageTranslated();
        }

        private ErrorMessageInformation CreateErrorMessageTranslated()
        {
            return new ErrorMessageInformation()
            {
                EntityName = GetEntityTranslated(),
                ErrorMessage = GetErrorMessage() 
            };
        }
        
        private string GetErrorMessage()
        {
            return new ResourceManager(typeof(Localization)).GetString(errorMessageList[1]) + GetMaximumValue();
        }

        private string GetEntityTranslated()
        {
            return new ResourceManager(typeof(Localization)).GetString(errorMessageList[0]);
        }

        private string GetMaximumValue()
        {
            return errorMessageList.Length > 2 ? " " + errorMessageList[2] + "." : "";
        }
        
        private void SplitErrorMessage()
        {
            errorMessageList = errorMessage.Split('_');
        }
    }
}
