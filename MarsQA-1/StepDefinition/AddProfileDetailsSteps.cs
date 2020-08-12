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
        //ProfileDetail ProfileDetail = new ProfileDetail();
        [When(@"I try to add new language on the profile page")]
        public void WhenITryToAddNewLanguageOnTheProfilePage()
        {
            //Calling the method for adding language
            ProfileDetail ProfileDetail = new ProfileDetail();
            ProfileDetail.AddLanguage();
        }

        [Then(@"Seller should able to add new language successfully")]
        public void ThenSellerShouldAbleToAddNewLanguageSuccessfully()
        {
            //Reading Language from Data excel sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.Excelpath_LanguageData, "Language");
            String ExpectedLanguage = ExcelLibHelper.ReadData(2, "Language");
            

            //Asserting the Language text
            String ActualLanguage = Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]")).Text;
            Assert.AreEqual(ActualLanguage, ExpectedLanguage);
            Console.WriteLine("Language" + " " + ActualLanguage + " " + "is added");

            //Reading Language Level from Data excel sheet
            String languageLevelData = ExcelLibHelper.ReadData(2, "LanguageLevel");


            //Asserting the Language level
            String ActualLevel = Driver.driver.FindElement(By.XPath("//tbody//tr[1]//td[2]")).Text;
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
            String DeleteAlertPopupText = Driver.driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Assert.IsTrue(DeleteAlertPopupText.Contains("deleted"));
            Console.WriteLine(DeleteAlertPopupText);
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
            String AddAlertPopupText = Driver.driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Assert.IsTrue(AddAlertPopupText.Contains("added"));
            Console.WriteLine(AddAlertPopupText);
        }


        [When(@"I update the education detail'(.*)'")]
        public void WhenIUpdateTheEducationDetail(string Title)
        {
           ProfileDetail ProfileDetail = new ProfileDetail();
           ProfileDetail.UpdateEducation(Title);
        }

        [Then(@"I should be able to update the education detail successfully")]
        public void ThenIShouldBeAbleToUpdateTheEducationDetailSuccessfully()
        {
            String UpdateAlertPopupText = Driver.driver.FindElement(By.ClassName("ns-box-inner")).Text;
            Assert.IsTrue(UpdateAlertPopupText.Contains("updated"));
            Console.WriteLine(UpdateAlertPopupText);
        }

    }
}
