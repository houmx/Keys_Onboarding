using Keys_Onboarding.Global;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages.Owners.Properties
{
    class AddNewPropertyPage
    {
        public AddNewPropertyPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Property Section WebElements Definition

        //Define property details section header
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/h2")]
        private IWebElement PropertyFormHeader { set; get; }

        //Define property type dropdown button
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[1]/div[2]/div/div[1]")]
        private IWebElement PropertyTypeDropdownButton { set; get; }

        //Define property name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Enter property name']")]
        private IWebElement PropertyNameText { set; get; }

        //Define property type
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[1]/div[2]/div")]
        private IWebElement PropertyTypeSelection { set; get; }
        
        //Define search street
        [FindsBy(How = How.XPath, Using = "//input[@name='searchAddress']")]
        private IWebElement SearchStreetText { set; get; }

        //Define number
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Number']")]
        private IWebElement NumberText { set; get; }

        //Define street        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Street']")]
        private IWebElement StreetText { set; get; }

        //Define suburb        
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Suburb']")]
        private IWebElement SuburbText { set; get; }

        //Define City
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  City']")]
        private IWebElement CityText { set; get; }

        //Define post code
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='PostCode']")]
        private IWebElement PostCodeText { set; get; }

        //Define region
        [FindsBy(How = How.XPath, Using = "//input[@id='region']")]
        private IWebElement RegionText { set; get; }

        //Define descriptions
        [FindsBy(How = How.XPath, Using = "//textarea[@class='add-prop-desc']")]
        private IWebElement DescriptionText { set; get; }

        //Define year built
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Year Built']")]
        private IWebElement YearBuiltText { set; get; }

        //Define target rent
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Rent Amount']")]
        private IWebElement TargetRentText { set; get; }

        //Define target type
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[3]/div[2]/div/div[2]/div")]
        private IWebElement RentTypeSelection { set; get; }

        //Define land area
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Land Area']")]
        private IWebElement LandAreaText { set; get; }

        //Define floor area
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Floor Area']")]
        private IWebElement FloorAreaText { set; get; }
        
        //Define bedrooms
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of Bedrooms']")]
        private IWebElement BedroomsText { set; get; }

        //Define bathrooms
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of Bathrooms']")]
        private IWebElement BathroomsText { set; get; }

        //Define carparks
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of car parks']")]
        private IWebElement CarparksText { set; get; }

        //Define owner occupied
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        private IWebElement OwnerOccupiedCheckBox { set; get; }
        
        //Define next buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[7]/button[1]")]
        private IWebElement NextToFinanceSectionButton { set; get; }

        //Define cancel buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[7]/button[2]")]
        private IWebElement CancelPropertyDetailsButton { set; get; }

        //Define confirmation header
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[1]/h4")]
        private IWebElement ConfirmationHeaderText { set; get; }

        //Define confirmation body
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[2]/p")]
        private IWebElement ConfirmationBodyText { set; get; }

        //Define confirmation yes button
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[3]/button[1]")]
        private IWebElement ConfirmationYesButton { set; get; }

        //Define confirmation no button
        [FindsBy(How = How.XPath, Using = ".//*[@id='myModal']/div/div/div[3]/button[2]")]
        private IWebElement ConfirmationNoButton { set; get; }
        
        //Define Upload button
        [FindsBy(How = How.XPath, Using = ".//*[@id='file-upload']")]
        private IWebElement UploadFileButton { set; get; }


        #endregion

        #region Finance Section WebElements Definition

        //Define fiance details section header
        [FindsBy(How = How.XPath, Using = "//h2[contains(.,'Finance Details')]")]
        private IWebElement FianceFormHeader { set; get; }

        //Define purchase price
        [FindsBy(How = How.XPath, Using = "//input[@name='purchasePrice']")]
        private IWebElement PurchasePriceText { set; get; }

        //Define mortgage
        [FindsBy(How = How.XPath, Using = "//input[@name='mortgagePrice']")]
        private IWebElement MortgageText { set; get; }

        //Define  home value
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Enter Home Value']")]
        private IWebElement HomeValueText { set; get; }

        //Define  home value type
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[1]/div[4]/div")]
        private IWebElement HomeValueTypeSelection { set; get; }

        //Define previous button
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[8]/button[1]")]
        private IWebElement GoBackToPropertySectionButton { set; get; }
       
        //Define next buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[8]/button[3]")]
        private IWebElement NextToTenantSectionButton { set; get; }

        //Define cancel buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[8]/input")]
        private IWebElement CancelFianceDetailsButton { set; get; }

        #endregion

        #region Tenant Section WebElements Definition

        //Define tenant details section  header
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/h2")]
        private IWebElement TenantFormHeader { set; get; }

        //Define tenant email
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement TenantEmailText { set; get; }

        //Define is main tenant
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[2]/div")]
        private IWebElement IsMainTenantSelection { set; get; }

        //Define firstname
        [FindsBy(How = How.XPath, Using = "//input[@id='fname']")]
        private IWebElement FirstnameText { set; get; }

        //Define  lastname
        [FindsBy(How = How.XPath, Using = "//input[@id='lname']")]
        private IWebElement LastnameText { set; get; }

        //Define start date
        [FindsBy(How = How.XPath, Using = "//input[@id='sdate']")]
        private IWebElement StartDatePicker { set; get; }

        //Define end date
        [FindsBy(How = How.XPath, Using = "//input[@id='edate']")]
        private IWebElement EndDatePicker { set; get; }

        //Define rent amount
        [FindsBy(How = How.XPath, Using = "//input[@id='ramount']")]
        private IWebElement RentAmountText { set; get; }

        //Define payment frequency
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[8]/div")]
        private IWebElement PaymentFrequencySelection { set; get; }

        //Define payment start date
        [FindsBy(How = How.XPath, Using = "//input[@id='psdate']")]
        private IWebElement PaymentStartDatePicker { set; get; }

        //Define payment due day
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[10]/div")]
        private IWebElement PaymentDueDaySelection { set; get; }

        //Define previous buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='addProperty']")]
        private IWebElement GoBackToFinanceSectionButton { set; get; }

        //Define save buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='saveProperty']")]
        private IWebElement SaveButton { set; get; }

        //Define cancel buttom
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[5]/input")]
        private IWebElement CancelTenantDetailsButton { set; get; }

        #endregion

        #region Actions for Property Details Section

        //Check if property details form header display
        internal bool IsPropertyFormHeaderDisplayed()
        {
            if (PropertyFormHeader.Displayed)
                return true;
            else
                return false;
        }

        //Fill out the property details form
        internal void AddPropertyDetails()
        {

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Property Details");

            PropertyTypeDropdownButton.Click();
            Driver.driver.FindElement(By.XPath("//div[@class='item'][contains(text(),'Short-Term Rental')]")).Click();

            // Navigating to Property Details using value from Excel
            PropertyNameText.SendKeys(ExcelLib.ReadData(2,"Property Name"));
            NumberText.SendKeys(ExcelLib.ReadData(2, "Number"));
            StreetText.SendKeys(ExcelLib.ReadData(2, "Street"));
            DescriptionText.SendKeys(ExcelLib.ReadData(2, "Description"));
            CityText.SendKeys(ExcelLib.ReadData(2, "City"));
            PostCodeText.SendKeys(ExcelLib.ReadData(2, "PostCode"));
            RegionText.SendKeys(ExcelLib.ReadData(2,"Region"));
            YearBuiltText.SendKeys(ExcelLib.ReadData(2, "Year Built"));
            TargetRentText.SendKeys(ExcelLib.ReadData(2, "Target Rent"));
            BedroomsText.SendKeys(ExcelLib.ReadData(2, "Bedrooms"));
            BathroomsText.SendKeys(ExcelLib.ReadData(2, "Bathrooms"));
            CarparksText.SendKeys(ExcelLib.ReadData(2, "Carparks"));

            UploadFileButton.SendKeys(ExcelLib.ReadData(2, "Choose Files"));
  

        }

        //Click next button , go to finance details form
        internal void GotoFinanceForm()
        {
            Driver.WaitForElementClickable(Driver.driver, By.XPath(".//*[@id='property-details']/div[7]/button[1]"),15);
            NextToFinanceSectionButton.Click();
        }

        //Click cancel button
        internal void CancelPropertyForm()
        {
            CancelPropertyDetailsButton.Click();
        }

        //Check if cancel confirmation dialog display
        internal bool IsCancelConfirmationDialogDisplayed()
        {
            if (ConfirmationHeaderText.Displayed & ConfirmationBodyText.Displayed)
                return true;
            else
                return false;
        }

        //confirm to cancel 
        internal void ConfirmCancel()
        {
            ConfirmationYesButton.Click();
        }

        //quit to cancel  
        internal void QuitCancel()
        {
            ConfirmationNoButton.Click();
        }



        

        #endregion

        #region Actions for Finance details Section
        //Check if finance form header displayed
        internal bool IsFianceFormHeaderDisplayed()
        {
            if (FianceFormHeader.Displayed)
                return true;
            else
                return false;
        }

        //Fill out the fiance details form
        internal void AddFinanceDetails()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Finance Details");

            // Navigating to Property Details using value from Ex
            PurchasePriceText.SendKeys(ExcelLib.ReadData(2, "Purchase Price"));
            MortgageText.SendKeys(ExcelLib.ReadData(2, "Mortgage"));
            HomeValueText.SendKeys(ExcelLib.ReadData(2, "Home Value"));
        }
        
        //Click next button, go to tenant details form
        internal void GotoTenantForm()
        {
            NextToTenantSectionButton.Click();
        }

        //Click previous button, go back to property details form
        internal void GoBackToPropertyForm()
        {
            GoBackToPropertySectionButton.Click();
        }

        //Click cancel button
        internal void CanceFianceForm()
        {
            CancelFianceDetailsButton.Click();
        }

        #endregion

        #region Actions for Tenant Details Section

        //Check if tenant details section  header display
        internal bool IsTenantFormHeaderDisplayed()
        {
            if (TenantFormHeader.Displayed)
                return true;
            else
                return false;

        }

        //Fill out tenant details form
        internal void AddTenantDetails()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Tenant Details");

            // Navigating to Property Details using value from Excel
            TenantEmailText.SendKeys(ExcelLib.ReadData(2, "Tenant Email"));
            FirstnameText.SendKeys(ExcelLib.ReadData(2, "First Name"));
            LastnameText.SendKeys(ExcelLib.ReadData(2, "Last Name"));
            StartDatePicker.Click();
            EndDatePicker.Click();
            RentAmountText.SendKeys(ExcelLib.ReadData(2, "Rent Amount"));
            PaymentStartDatePicker.Click();
        }

        //Click previous button, go back to finance details form
        internal void GoBackToFianceForm()
        {

            GoBackToFinanceSectionButton.Click();
        }

        //Click save button
        internal void SaveProperty()
        {
            SaveButton.Click();
        }

        //Click cancel button
        internal void CanceTenantForm()
        {
            CancelTenantDetailsButton.Click();
        }

        #endregion

    }
}
