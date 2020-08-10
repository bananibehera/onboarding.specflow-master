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

       
        public void AddLanguage()
        {



            for (int i = 1; i <= 4; i++)

            {

                //Reading language data from excel sheet
                ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
                var languageData = ExcelLibHelper.ReadData(i + 1, "Language");
                
                //Clicking on Add new button
                IWebElement addNewLanguageBtn = Driver.driver.FindElement(By.XPath(" (//div[@class='ui teal button '][contains(text(),'Add New')])[1]"));
                addNewLanguageBtn.Click();

                //Entering the language data into the language textbox
                IWebElement addNewLanguageTxt = Driver.driver.FindElement(By.XPath(" //input[contains(@placeholder,'Add Language')]"));
                addNewLanguageTxt.SendKeys(languageData);

                //Selecting the language level
                IWebElement LanguageLevelDrpdwn = Driver.driver.FindElement(By.XPath(" //select[contains(@class,'ui dropdown')]"));
                SelectElement chooseLanguageLevel = new SelectElement(LanguageLevelDrpdwn);
                //select.SelectByText(ConstantHelpers.LevelFluent);
                var languageLevelData = ExcelLibHelper.ReadData(i + 1, "LanguageLevel");
                chooseLanguageLevel.SelectByValue(languageLevelData);

                //Clicking Add button
                IWebElement addButton = Driver.driver.FindElement(By.XPath(" //input[@class='ui teal button'][contains(@value, 'Add')]"));
                addButton.Click();
            }
        }

       

        public void DeleteLanguage()
        {
            //Delete an existing language from the language list 
            IWebElement deleteLanguageBtn = Driver.driver.FindElement(By.XPath(" (//i[contains(@class,'remove icon')])[1]"));
            deleteLanguageBtn.Click();
            IWebElement DeleteAlertPopup = Driver.driver.FindElement(By.ClassName("ns-box-inner"));
            String ExpectedAlertText = DeleteAlertPopup.Text;
            Assert.IsTrue(ExpectedAlertText.Contains("deleted"));


        }
          public void AddEducation(String Year, String Country, String Title)
        //public void AddEducation()
        {
            //Populating data from Data excel sheet and reading the test data 
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Education");
            var collegeNametxt = ExcelLibHelper.ReadData(2, "College/University Name");
            var degreeTxt = ExcelLibHelper.ReadData(2, "Degree");
            //var yearDrpdwn = ExcelLibHelper.ReadData(2, "Year");

            // Clicking on the Education tab
            IWebElement educationTab = Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Education')]"));
            educationTab.Click();

            //Clicking the addNew button
            IWebElement addNewButton = Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[2]"));
            addNewButton.Click();

            //Entering the College/University name
            IWebElement collegeNameTextbox = Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'College/University Name')]"));
            collegeNameTextbox.SendKeys(collegeNametxt);

            //Entering the degree
            IWebElement degreeTextbox = Driver.driver.FindElement(By.XPath("//input[contains(@placeholder,'Degree')]"));
            degreeTextbox.SendKeys(degreeTxt);

            //Selecting the country
            SelectElement countryDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name,'country')]")));
            countryDropdown.SelectByText(Country);
            

            //Selecting the Title
            SelectElement titleDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name,'title')]")));
            titleDropdown.SelectByText(Title);
            
            //Selecting the year
            SelectElement yearDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name,'yearOfGraduation')]")));
            yearDropdown.SelectByText(Year);
            
            //Clicking add button 
            IWebElement addButton = Driver.driver.FindElement(By.XPath("//input[contains(@class,'ui teal button ')]"));
            addButton.Click();
        }

        public void UpdateEducation(String Title)
        {
            // Clicking on the Education tab
            IWebElement educationTab = Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Education')]"));
            educationTab.Click();

            // Clicking on the Edit button of the added education
            IWebElement editEducationButton = Driver.driver.FindElement(By.XPath("(//i[@class='outline write icon'])[8]"));
            //IWebElement editEducationButton = Driver.driver.FindElement(By.XPath("/div[@class='ui bottom attached tab segment tooltip-target active']//i[@class='outline write icon']"));
            editEducationButton.Click();

            //Updating Title
            SelectElement titleDropdown = new SelectElement(Driver.driver.FindElement(By.XPath("//select[contains(@name,'title')]")));
            titleDropdown.SelectByText(Title);
            IWebElement updateEducationButton = Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]"));
            updateEducationButton.Click();


        }

    }

}
    
