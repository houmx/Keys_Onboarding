using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages.Owners.Properties
{
    class ListRentalPropertyPage
    {
        public ListRentalPropertyPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition 

        //Define header    
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div/h2")]
        private IWebElement HeaderText { set; get; }

        //Define select property     
        [FindsBy(How = How.XPath, Using = "//select[@data-bind='value : PropertyId']")]
        private IWebElement SelectPropertyDropdown { set; get; }

        //Define title
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[2]/div[1]/input[1]")]
        private IWebElement TitleText { set; get; }

        //Define moving cost
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[2]/div[1]/input[2]")]
        private IWebElement MovingCostText { set; get; }

        //Define description
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[2]/div[2]/textarea")]
        private IWebElement DescriptionText { set; get; }

        //Define target rent
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[3]/div[1]/input")]
        private IWebElement TargentRentText { set; get; }

        //Define furnishing
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[3]/div[2]/input")]
        private IWebElement FurnishingText { set; get; }

        //Define available date
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[4]/div[1]/input")]
        private IWebElement AvailableDateDatepicker { set; get; }

        //Define occupants count
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[5]/div[1]/input")]
        private IWebElement OccupantsCountText { set; get; }

        //Define pet allowed
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[5]/div[2]/select")]
        private IWebElement PetAllowedDropdown { set; get; }

        //Define choose files
        [FindsBy(How = How.XPath, Using = ".//*[@id='file-upload']")]
        private IWebElement ChooseFilesButton { set; get; }

        //Define save
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[9]/div/button[1]")]
        private IWebElement SaveButton { set; get; }

        //Define cancel
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/form/div[9]/div/button[2]")]
        private IWebElement CancelButton { set; get; }

        //Define confirmation dialog 
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[2]/p")]
        private IWebElement ConfirmationDialogText { set; get; }

        //Define confirmation dialog yes button
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[3]/button[1]")]
        private IWebElement ConfirmationDialogYesButton { set; get; }

        //Define confirmation dialog no button
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[3]/button[2]")]
        private IWebElement ConfirmationDialogNoButton { set; get; }

        #endregion

        internal void AddRentalPropertyDetails()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "List Rental Property");

            SelectElement select1 = new SelectElement(SelectPropertyDropdown);
            select1.SelectByIndex(1);
            TitleText.SendKeys(ExcelLib.ReadData(2, "Title"));
            MovingCostText.SendKeys(ExcelLib.ReadData(2, "Moving Cost"));
            DescriptionText.SendKeys(ExcelLib.ReadData(2, "Description"));
            TargentRentText.SendKeys(ExcelLib.ReadData(2, "Target Rent"));

            AvailableDateDatepicker.Click();
            OccupantsCountText.SendKeys(ExcelLib.ReadData(2, "Occupants Count"));

            SelectElement select2 = new SelectElement(PetAllowedDropdown);
            select2.SelectByText("Yes");

            //upload file
            ChooseFilesButton.SendKeys(ExcelLib.ReadData(2, "Choose Files"));

        }

        internal void SaveListRentalProperty()
        {
            SaveButton.Click();
        }

        internal void CancelListRentalProperty()
        {
            CancelButton.Click();
        }

        internal bool IsHeaderDisplayed()
        {
            Driver.WaitForElementVisible(Driver.driver, By.XPath(".//*[@id='main-content']/section/div[1]/div/div/h2"), 3);

            if (HeaderText.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool IsConfirmationDialogDisplay()
        {
            Driver.WaitForElementVisible(Driver.driver,By.XPath(".//*[@id='myModal']/div/div/div[2]/p"),3);

            if (ConfirmationDialogText.Displayed & ConfirmationDialogText.Text.Equals("Do you want to leave this page without saving?"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void ConfirmToCancel()
        {
            Driver.WaitForElementVisible(Driver.driver, By.XPath(".//*[@id='myModal']/div/div/div[2]/p"), 3);
            ConfirmationDialogYesButton.Click();
        }

        internal void QuitToCancel()
        {
            Driver.WaitForElementVisible(Driver.driver, By.XPath(".//*[@id='myModal']/div/div/div[2]/p"), 3);
            ConfirmationDialogNoButton.Click();
        }


    }
}
