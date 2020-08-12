using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using ExcelDataReader;
using System.Data;
using MarsQA_1.SpecflowPages.Helpers;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class ProfileDetail
    {
        private static IWebElement addNewLanguageBtn => Driver.driver.FindElement(By.XPath(" (//div[@class='ui teal button '][contains(text(),'Add New')])[1]"));
        private static IWebElement addNewLanguageTxt => Driver.driver.FindElement(By.XPath(" //input[contains(@placeholder,'Add Language')]"));
        private static IWebElement LanguageLevelDrpdwn => Driver.driver.FindElement(By.XPath(" //select[contains(@class,'ui dropdown')]"));
        private static IWebElement addButton_Langauge => Driver.driver.FindElement(By.XPath(" //input[@class='ui teal button'][contains(@value, 'Add')]"));
        private static IWebElement deleteLanguageBtn => Driver.driver.FindElement(By.XPath(" (//i[contains(@class,'remove icon')])[1]"));
        private static IWebElement educationTab => Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Education')]"));
        private static IWebElement addNewButton_Education => Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[2]"));
        private static IWebElement collegeNameTextbox => Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'College/University Name')]"));
        private static IWebElement degreeTextbox => Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Degree')]"));
        private static IWebElement addButton_Education => Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]"));
        private static IWebElement countryDropdown => Driver.driver.FindElement(By.XPath("//select[contains(@name,'country')]"));
        private static IWebElement titleDropdown => Driver.driver.FindElement(By.XPath("//select[contains(@name,'title')]"));
        private static IWebElement yearDropdown => Driver.driver.FindElement(By.XPath("//select[contains(@name,'yearOfGraduation')]"));
        private static IWebElement editEducationButton => Driver.driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[5]"));
        private static IWebElement updateEducationButton => Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]"));

        public void AddLanguage()
        {



            for (int i = 1; i <= 4; i++)

            {

                //Reading language data from excel sheet
                ExcelLibHelper.PopulateInCollection(ConstantHelpers.Excelpath_LanguageData, "Language");
                var languageData = ExcelLibHelper.ReadData(i + 1, "Language");
                
                //Clicking on Add new button
                addNewLanguageBtn.Click();

                //Entering the language data into the language textbox
                addNewLanguageTxt.SendKeys(languageData);

                //Selecting the language level
                SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDrpdwn);
                var languageLevelData = ExcelLibHelper.ReadData(i + 1, "LanguageLevel");
                chooseLanguageLevel.SelectByValue(languageLevelData);

                //Clicking Add button
                addButton_Langauge.Click();
            }
        }

       

        public void DeleteLanguage()
        {
            //Delete an existing language from the language list 
            deleteLanguageBtn.Click();
            

        }
          public void AddEducation(String Year, String Country, String Title)
        //public void AddEducation()
          {
            //Populating data from Data excel sheet and reading the test data 
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.Excelpath_LanguageData, "Education");
            var collegeNametxt = ExcelLibHelper.ReadData(2, "College/University Name");
            var degreeTxt = ExcelLibHelper.ReadData(2, "Degree");
            

            // Clicking on the Education tab
            educationTab.Click();

            GenericWait.ElementIsClickable(Driver.driver, "XPath", "(//div[@class='ui teal button '][contains(.,'Add New')])[2]", 5);
            
            //Clicking the addNew button
            addNewButton_Education.Click();

            //Entering the College/University name
            collegeNameTextbox.SendKeys(collegeNametxt);

            //Entering the degree
            degreeTextbox.SendKeys(degreeTxt);

            //Selecting the country
            SelectElement elementcountry_drpdwn = new SelectElement(countryDropdown);
            elementcountry_drpdwn.SelectByText(Country);


            //Selecting the Title
            SelectElement elementtitle_drpdwn = new SelectElement(titleDropdown);
            elementtitle_drpdwn.SelectByText(Title);

            //Selecting the year
            SelectElement elementyear_drpdwn = new SelectElement(yearDropdown);
            elementyear_drpdwn.SelectByText(Year);

            //Clicking add button 
            addButton_Education.Click();
          }
           

        public void UpdateEducation(String Title)
        {
            // Clicking on the Education tab
            educationTab.Click();

            GenericWait.ElementExists(Driver.driver, "XPath", "(//i[contains(@class,'outline write icon')])[5]", 5);
            
            // Clicking on the Edit button of the added education
            editEducationButton.Click();

            //Updating Title
            SelectElement elementtitle_drpdwn= new SelectElement(titleDropdown);
            elementtitle_drpdwn.SelectByText(Title);
            updateEducationButton.Click();


        }

    }

}
    
