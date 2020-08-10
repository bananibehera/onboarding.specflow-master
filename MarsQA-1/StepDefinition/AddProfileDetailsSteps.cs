using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinition
{
    [Binding]
    public class AddProfileDetailsSteps
    {
        [When(@"I try to add new language on the profile page")]
        public void WhenITryToAddNewLanguageOnTheProfilePage()
        {
            //Calling the method for adding language
            var ProfileDetail = new ProfileDetail();
            ProfileDetail.AddLanguage();
        }

        [Then(@"Seller should able to add new language successfully")]
        public void ThenSellerShouldAbleToAddNewLanguageSuccessfully()
        {
            //Reading Language from Data excel sheet
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            var languageData = ExcelLibHelper.ReadData(2, "Language");
           
                String ExpectedLanguage = languageData;

                //Asserting the Language text
                IWebElement ActualLangTxt = Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"));
                String ActualLanguage = ActualLangTxt.Text;
                Assert.AreEqual(ActualLanguage, ExpectedLanguage);
                Console.WriteLine("Language" + " " + ActualLanguage + " " + "is added");

            //Reading Language Level from Data excel sheet
            var languageLevelData = ExcelLibHelper.ReadData(2, "LanguageLevel");

                //Asserting the Language text
                IWebElement AddedLanguageLevel = Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[2]"));
                String ActualLevel = AddedLanguageLevel.Text;
                Assert.AreEqual(ActualLevel, languageLevelData);
                Console.WriteLine("Level" + " " + ActualLevel + " " + "is added");
        }

              

        [When(@"I try to delete existing language")]
        public void WhenITryToDeleteExistingLanguage()
        {
            //Calling the method for deleting language
            var ProfileDetail = new ProfileDetail();
            ProfileDetail.DeleteLanguage();
        }
            
                  
        [Then(@"Seller able to delete existing language successfully")]
        public void ThenSellerAbleToDeleteExistingLanguageSuccessfully()
        {
            //Assertion for deleting the language
            IWebElement DeleteAlertPopup = Driver.driver.FindElement(By.ClassName("ns-box-inner"));
            String AlertText = DeleteAlertPopup.Text;
            Assert.IsTrue(AlertText.Contains("deleted"));
            Console.WriteLine(AlertText);
        }

        [When(@"I add education details '(.*)','(.*)','(.*)'")]
        public void WhenIAddEducationDetails(String Year, string Country, string Title)
        {
            var ProfileDetail = new ProfileDetail();
            ProfileDetail.AddEducation(Year, Country, Title);
        }
       
        [Then(@"I should be able to add education details successfully")]
        public void ThenIShouldBeAbleToAddEducationDetailsSuccessfully()
        {
            IWebElement AddAlertPopup = Driver.driver.FindElement(By.ClassName("ns-box-inner"));
            String AlertText = AddAlertPopup.Text;
            Assert.IsTrue(AlertText.Contains("added"));
            Console.WriteLine(AlertText);
        }


        [When(@"I update the education detail'(.*)'")]
        public void WhenIUpdateTheEducationDetail(string Title)
        {
            var ProfileDetail = new ProfileDetail();
            ProfileDetail.UpdateEducation(Title);
        }

        [Then(@"I should be able to update the education detail successfully")]
        public void ThenIShouldBeAbleToUpdateTheEducationDetailSuccessfully()
        {
            IWebElement UpdateAlertPopup = Driver.driver.FindElement(By.ClassName("ns-box-inner"));
            String AlertText = UpdateAlertPopup.Text;
            Assert.IsTrue(AlertText.Contains("updated"));
            Console.WriteLine(AlertText);
        }

    }
}
