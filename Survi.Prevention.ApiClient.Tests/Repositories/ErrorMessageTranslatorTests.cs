using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Localization;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
	[TestFixture]
    public class ErrorMessageTranslatorTestsEnglishTranslation
    {
        public ErrorMessageTranslatorTestsEnglishTranslation()
        {
            var cultureInfo = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        [TestCase]
        public static void EntityDescriptionIsValid()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "A value is missing." };
            Assert.AreEqual(errorMessage.FieldName,  new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").FieldName);
        }

        [TestCase]
        public static void EntityDescriptionIsNotValid()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "A value is missing." };
            Assert.AreNotEqual(errorMessage.FieldName, new ErrorMessageTranslator().GetErrorMessageTranslated("Numer_MissingValue").FieldName);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithoutMaxValueIsValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "A value is missing." };
            Assert.AreEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithoutMaxValueIsNotValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "A value is missing." };
            Assert.AreNotEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingVaue").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithMaxValueIsValid()
        {
                        var errorMsg = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "The maximum number of characters is 5." };
            Assert.AreEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_TooLong_5").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithMaxValueIsNotValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Number", ErrorMessage = "The maximum number of characters is 5." };
            Assert.AreNotEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_TooLong").ErrorMessage);
        }

        [TestCase]
        public static void TranslateErrorMessagesStringToObject()
        {
            var listOfErrors = new List<string>() {"Number_TooLong_4", "LastName_InvalidValue", "Quantity_NullValue"};
            var result = new List<ErrorMessageInformation>();
            result.Add(new ErrorMessageInformation(){ FieldName = "Number", ErrorMessage = "The maximum number of characters is 4."});
            result.Add(new ErrorMessageInformation(){ FieldName = "Last name", ErrorMessage = "The value is invalid."});
            result.Add(new ErrorMessageInformation(){ FieldName = "Quantity", ErrorMessage = "The value does not exist."});
            var test = new ErrorMessageTranslator().TranslateErrorMessages(listOfErrors);
            Assert.AreEqual(3, test.Count);
        }
    }

    [TestFixture]
    public class ErrorMessagesTestLanguages
    {
        [TestCase]
        public static void ErrorMessageWithFrenchCurrentCulture()
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            Assert.AreEqual("fr-CA",cultureInfo.Name);
        }

        [TestCase]
        public static void ErrorMessageWithEnglishCurrentCulture()
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            Assert.AreNotEqual("en-US", cultureInfo.Name);
        }

        [TestCase]
        public static void ErrorMessageReturnsRighValuesWithFrenchCurrentCulture()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Une valeur est manquante." };
            Assert.AreEqual(errorMessage.FieldName, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").FieldName);
        }
    }

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
            var errorMessage = new ErrorMessageInformation() { FieldName = "Numéro",ErrorMessage = "Une valeur est manquante." };
            Assert.AreEqual(errorMessage.FieldName,new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").FieldName);
        }

        [TestCase]
        public static void EntityDescriptionIsNotValid()
        {
            var errorMessage = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Une valeur est manquante." };
            Assert.AreNotEqual(errorMessage.FieldName, new ErrorMessageTranslator().GetErrorMessageTranslated("Numer_MissingValue").FieldName);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithoutMaxValueIsValid()
        {
            var errorMsg = new ErrorMessageInformation() {FieldName = "Numéro", ErrorMessage = "Une valeur est manquante."};
            Assert.AreEqual(errorMsg.ErrorMessage, new ErrorMessageTranslator().GetErrorMessageTranslated("Number_MissingValue").ErrorMessage);
        }

        [TestCase]
        public static void ErrorMessageDescriptionWithoutMaxValueIsNotValid()
        {
            var errorMsg = new ErrorMessageInformation() { FieldName = "Numéro", ErrorMessage = "Une valeur est manquante." };
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
    }
}
