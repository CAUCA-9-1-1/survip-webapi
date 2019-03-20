using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Localization;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class ErrorMessageTranslatorTestsFrenchTranslation
    {
        public ErrorMessageTranslatorTestsFrenchTranslation()
        {
            var cultureInfo = new CultureInfo("fr");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        [TestCase]
        public static void EntityDescriptionIsValid()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Numéro",ErrorMessage = "Valeur manquante." };
            Assert.AreEqual(errorMessage.FieldName,new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").FieldName);
        }

        [TestCase]
        public static void EntityDescriptionIsNotValid()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Valeur manquante." };
            Assert.AreNotEqual(errorMessage.FieldName, new ErrorMessageTranslator().GetErrorMessageTranslated("Numer_MissingValue").FieldName);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithoutMaxValueIsValid()
        {
            var errorMsg = new ErrorMessageInformation() {FieldName = "Numéro", ErrorMessage = "Valeur manquante."};
            Assert.AreEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithoutMaxValueIsNotValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Valeur manquante." };
            Assert.AreNotEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingVaue").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithMaxValueIsValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Le nombre de caractères maximal est de 5." };
            Assert.AreEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_TooLong_5").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithMaxValueIsNotValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Le nombre de caractères maximal est de 5." };
            Assert.AreNotEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_TooLong").ErrorMessage);
        }

        [TestCase]
        public static void TranslateErrorMessagesStringToObject()
        {
            var listOfErrors = new List<string>() { "Number_TooLong_4", "LastName_InvalidValue", "Quantity_NullValue" };
            var result = new List<ErrorMessageInformation>();
            result.Add(new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Le nombre de caractères maximal est de 4." });
            result.Add(new ErrorMessageInformation() { FieldName = "Nom", ErrorMessage = "La valeur est invalide." });
            result.Add(new ErrorMessageInformation() { FieldName = "Quantité", ErrorMessage = "La valeur est inexistante." });
            var test = new ErrorMessageTranslator().TranslateErrorMessages(listOfErrors);
            Assert.AreEqual(3, test.Count);
        }

        [TestCase]
        public static void ErrorMessageDescriptionValidYear()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Année du code d'utilisation", ErrorMessage = "La valeur doit être entre 2000 et 2100." };
            Assert.AreEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("UtilizationCodeYear_InvalidYear").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionInvalidYear()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Année du code d'utilisation", ErrorMessage = "La valeur doit être entre 2000 et 2100." };
            Assert.AreNotEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("UtilizationCodeYear_Invalidyea").ErrorMessage);
        }
    }
}