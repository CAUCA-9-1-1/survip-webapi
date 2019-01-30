using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace Survi.Prevention.ApiClient.Localization
{
	public class ErrorMessageTranslator
    {
        private string[] errorMessageList;
        private CultureInfo currentCulture;

        public ErrorMessageTranslator()
        {
            currentCulture = CultureInfo.CreateSpecificCulture(Thread.CurrentThread.CurrentUICulture.Name);
        }
        public List<ErrorMessageInformation> TranslateErrorMessages(List<string> errors)
        {
            var errorList = new List<ErrorMessageInformation>();
            foreach (var error in errors)
            {
                errorList.Add(GetErrorMessageTranslated(error));
            }
            return errorList;
        }

        public ErrorMessageInformation GetErrorMessageTranslated(string error)
        {
            SplitErrorMessage(error);
            return CreateErrorMessageTranslated(error);
        }

        private ErrorMessageInformation CreateErrorMessageTranslated(string error)
        {
            return new ErrorMessageInformation()
            {
                FieldName = GetEntityTranslated() ?? error,
                ErrorMessage = GetErrorMessage() ?? error
            };
        }
        
        private string GetErrorMessage()
        {
            return new ResourceManager(typeof(Localization)).GetString(errorMessageList[1], currentCulture) + GetMaximumValue();
        }

        private string GetEntityTranslated()
        {
            return new ResourceManager(typeof(Localization)).GetString(errorMessageList[0],currentCulture);
        }

        private string GetMaximumValue()
        {
            return errorMessageList.Length > 2 ? " " + errorMessageList[2] + "." : "";
        }
        
        private void SplitErrorMessage(string error)
        {
            if (error.Contains("_"))
            {
                errorMessageList = error.Split('_');
            }
            else
            {
                errorMessageList[0] = error;
            }
        }
    }
}
