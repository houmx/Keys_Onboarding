using Keys_Onboarding.Global;
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
    class AddTenantPage
    {
        public AddTenantPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Tenant Details WebElements Definition

        //Define tenant email  
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Tenant Email']")]
        private IWebElement TenantEmailText { set; get; }

        //Define tenant email  already exist warning
        [FindsBy(How = How.XPath, Using = "//html//div[2]/div[1]/div[1]/span[1]")]
        private IWebElement TenantEmailAlreadyExistWarningText { set; get; }
        

        //Define is main tenant dropdown
        [FindsBy(How = How.XPath, Using = "//select[@data-bind='value : IsMainTenant']")]
        private IWebElement IsMainTenantDropdown { set; get; }

        //Define first name
        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div/div[3]/div[1]/div/input")]
        private IWebElement FirstNameText { set; get; }

        //Define last name
        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div/div[3]/div[2]/div/input")]
        private IWebElement LastNameText { set; get; }

        //Define rent start date
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Rent Start Date']")]
        private IWebElement RentStartDatepicker { set; get; }

        //Define rent end date
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Rent End Date']")]
        private IWebElement RentEndDatepicker { set; get; }

        //Define  rent amount
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Rent Amount']")]
        private IWebElement RentAmountText { set; get; }

        //Define payment frequency
        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div/div[5]/div[2]/div/select")]
        private IWebElement PaymentFrequencyDropdown { set; get; }

        //Define payment start date
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Payment Start Date']")]
        private IWebElement PaymentStartDatepicker { set; get; }

        //Define payment due date
        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div/div[6]/div[2]/div/select")]
        private IWebElement PaymentDueDateDropdown { set; get; }

        //Define next to liabilities details button
        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div/div[7]/div/div/input[1]")]
        private IWebElement NextToLiabilitiesDetailsButton { set; get; }

        //Define cancel tenant details button
        [FindsBy(How = How.XPath, Using = ".//*[@id='BasicDetail']/div/div[7]/div/div/input[2]")]
        private IWebElement CancelTenantDetailsButton { set; get; }


        #endregion

        #region Liabilities Details WebElements Definition

        //Define add new liability
        [FindsBy(How = How.XPath, Using = "//a[contains(.,' Add New Liability')]")]
        private IWebElement AddNewLiabilityButton { set; get; }


        //Define liability name dropdown 
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr/td[1]/select")]
        private IWebElement LiabilityNameDropdown { set; get; }

        //Define amount
        [FindsBy(How = How.XPath, Using = "//td[@class='col-md-3']//input[@class='form-control']")]
        private IWebElement AmountText { set; get; }

        //Define save new liability
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr/td[3]/input")]
        private IWebElement SaveNewLiabilityButton { set; get; }

        //Define cancel new liability
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr/td[3]/button[1]")]
        private IWebElement CancelNewLiabilityButton { set; get; }

        //Define previous
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[2]/button[1]")]
        private IWebElement PreviousToTenantDetailsButton { set; get; }

        //Define next
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[2]/button[2]")]
        private IWebElement NextToSummaryButton { set; get; }

        //Define cancel
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[2]/input")]
        private IWebElement CancelLiabilityDetailsButton { set; get; }


        #endregion

        #region Summary Webelements Definition

        //Define tenant email
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[3]/div[1]/div/input")]
        private IWebElement SummaryTenantEmailText { set; get; }

        //Define is main tenant 
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[3]/div[2]/div/select")]
        private IWebElement SummaryIsMainTenantText { set; get; }

        //Define first name
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[4]/div[1]/div/input")]
        private IWebElement SummaryFirstNameText { set; get; }

        //Define last name
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[4]/div[2]/div/input")]
        private IWebElement SummaryLastNameText { set; get; }

        //Define rent start date
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[5]/div[1]/div/input")]
        private IWebElement SummaryRentStartDateText { set; get; }

        //Define rent end date
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[5]/div[2]/div/input")]
        private IWebElement SummaryRentEndDateText { set; get; }

        //Define rent amount
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[6]/div[1]/div/input")]
        private IWebElement SummaryRentAmount { set; get; }

        //Define payment frequency
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[6]/div[2]/div/select")]
        private IWebElement SummaryPaymentFrequencyText { set; get; }

        //Define payment start date
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[7]/div[1]/div/input")]
        private IWebElement SummaryPaymentStartDateText { set; get; }

        //Define payment due date
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[7]/div[2]/div/select")]
        private IWebElement SummaryPaymentDueDateText { set; get; }

        //Define liability name
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[9]/div/table/tbody/tr/td[1]/span")]
        private IWebElement SummaryLiabilityNameText { set; get; }

        //Define amount
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[9]/div/table/tbody/tr/td[2]/span")]
        private IWebElement SummaryAmountText { set; get; }
        
        #endregion

        #region Summary WebElements Definition
        //Define previous button
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[10]/div/button[1]")]
        private IWebElement PreviousToLiabilityDetailsButton { set; get; }

        //Define submit button
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[10]/div/button[2]")]
        private IWebElement SubmitButton { set; get; }

        //Define cancel button
        [FindsBy(How = How.XPath, Using = ".//*[@id='SummaryDetail']/div[10]/div/input")]
        private IWebElement CancelSummaryButton { set; get; }

        #endregion

        internal void AddTenantDetails()
        {

            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            //enter the tenant email
            TenantEmailText.SendKeys(ExcelLib.ReadData(2, "Tenant Email"));

            //select is main tenant
            String isMainTenant = ExcelLib.ReadData(2, "Is Main Tenant");
            SelectElement select1 = new SelectElement(IsMainTenantDropdown);
            switch (isMainTenant)
            {
                case "Yes":
                    select1.SelectByValue("true");
                    break;
                case "No":
                    select1.SelectByValue("false");
                    break;
            }
            try
            {
                //enter first name and last name
                Thread.Sleep(1000);
                FirstNameText.SendKeys(ExcelLib.ReadData(2, "First Name"));
                Thread.Sleep(1000);
                LastNameText.SendKeys(ExcelLib.ReadData(2, "Last Name"));
            }
            catch(Exception e)
            {
                Console.Write("enter first name and last name exception: " + e.Message);
            }


            //select rent start date
            string rentStartDate = ExcelLib.ReadData(2, "Rent Start Date");
            string[] temp = rentStartDate.Split(' ');
            rentStartDate = temp[0];
            RentStartDatepicker.Click();
            RentStartDatepicker.Clear();
            RentStartDatepicker.SendKeys(rentStartDate);

            //select rent end date
            string rentEndDate = ExcelLib.ReadData(2, "Rent End Date");
            temp = rentEndDate.Split(' ');
            rentEndDate = temp[0];
            RentEndDatepicker.Click();
            RentEndDatepicker.Clear();
            RentEndDatepicker.SendKeys(rentEndDate);

            //enter rent amount
            RentAmountText.SendKeys(ExcelLib.ReadData(2, "Rent Amount"));

            //select payment frequency
            String paymentFrequency = ExcelLib.ReadData(2, "Payment Frequency");
            SelectElement select2 = new SelectElement(PaymentFrequencyDropdown);
            switch (paymentFrequency)
            {
                case "Weekly":
                    select2.SelectByValue("1");
                    break;
                case "Fortnightly":
                    select2.SelectByValue("2");
                    break;
                case "Monthly":
                    select2.SelectByValue("3");
                    break;
            }

            //select payment start date
            string PaymentStartDate = ExcelLib.ReadData(2, "Payment Start Date");
            temp = PaymentStartDate.Split(' ');
            PaymentStartDate = temp[0];
            PaymentStartDatepicker.Click();
            PaymentStartDatepicker.Clear();
            PaymentStartDatepicker.SendKeys(PaymentStartDate);

            //select payment due date
            String paymentDuedate = ExcelLib.ReadData(2, "Payment Due Date");
            SelectElement select3 = new SelectElement(PaymentDueDateDropdown);
            switch (paymentDuedate)
            {
                case "1":
                    select3.SelectByValue("1");
                    break;
                case "2":
                    select3.SelectByValue("2");
                    break;
                case "3":
                    select3.SelectByValue("3");
                    break;
                case "4":
                    select3.SelectByValue("4");
                    break;
                case "5":
                    select3.SelectByValue("5");
                    break;
                case "6":
                    select3.SelectByValue("6");
                    break;
                case "7":
                    select3.SelectByValue("7");
                    break;
            }
        }

        internal void AddExistingTenantDetails()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            TenantEmailText.SendKeys(ExcelLib.ReadData(3, "Tenant Email"));
            FirstNameText.SendKeys(ExcelLib.ReadData(2, "First Name"));
        }

        internal bool IsTenantAlreadyInThisPropertyWarningMessageDisplayed()
        {
            try
            {
                if(TenantEmailAlreadyExistWarningText.Text.Equals("Tenant is already in property!"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        internal bool IsNextButtonUnclickableUnderTenatDetails()
        {
            if(NextToLiabilitiesDetailsButton.Enabled)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void NextToLiabilityDetails()
        {
            NextToLiabilitiesDetailsButton.Click();
        }

        internal void CancelTenantDetails()
        {
            CancelTenantDetailsButton.Click();
        }

        internal bool IsAddNewLiabilityButtonDisplay()
        {
            try
            {
                if (AddNewLiabilityButton.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal bool IsSubmitButtonDisplay()
        {
            try
            {
                if (SubmitButton.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        internal void ClickAddNewLiability()
        {
            AddNewLiabilityButton.Click();
        }

        internal void AddLiabilityDetails()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            SelectElement select = new SelectElement(LiabilityNameDropdown);
            String liabilityName = ExcelLib.ReadData(2, "Liability Name");
            switch (liabilityName)
            {
                case "Bond":
                    select.SelectByValue("1");
                    break;

                case "Insurance":
                    select.SelectByValue("2");
                    break;

                case "Letting Fee":
                    select.SelectByValue("3");
                    break;

                case "Body Corp":
                    select.SelectByValue("4");
                    break;
            }

            AmountText.SendKeys(ExcelLib.ReadData(2, "Amount"));

        }

        internal void SaveNewLiability()
        {
            SaveNewLiabilityButton.Click();
        }

        internal void CancelNewLiability()
        {
            CancelNewLiabilityButton.Click();
        }

        internal bool FindLiabilitySuccessfully(String liabilityName, String amount)
        {
            try
            {
                //get the total number of liabilities
                int liaCount = Driver.driver.FindElements(By.XPath(".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr/td[1]/span")).Count;

                for (int i = 1; i <= liaCount; i++)
                {
                    string lia = Driver.driver.FindElement(By.XPath(".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr[" + i + "]/td[1]/span")).Text;
                    if (lia.Equals(liabilityName))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }

        }

        internal void GoBackToTenantDetails()
        {
            PreviousToTenantDetailsButton.Click();
        }

        internal void NextToSummary()
        {
            NextToSummaryButton.Click();
        }

        internal void CancelLiabilityDetails()
        {
            CancelLiabilityDetailsButton.Click();
        }

        internal void GoBackToLiabilityDetails()
        {
            PreviousToLiabilityDetailsButton.Click();
        }

        internal void Submit()
        {
            SubmitButton.Click();
        }

        internal void CancelSummary()
        {
            CancelSummaryButton.Click();
        }

        internal bool ValidateDataInSummary()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");

            try
            {
                //validate tenant email
                string expectedTenantEmail = ExcelLib.ReadData(2, "Tenant Email");
                string actualTenantEmail = SummaryTenantEmailText.Text;
                if (!expectedTenantEmail.Equals(actualTenantEmail))
                {
                    return false;
                }
                //validate is main tenant
                string expectedIsMainTenant = ExcelLib.ReadData(2, "Is Main Tenant");
                string actualIsMainTenant = SummaryIsMainTenantText.Text;
                if (!expectedIsMainTenant.Equals(actualIsMainTenant))
                {
                    return false;
                }
                //validate first name
                string expectedFirstName = ExcelLib.ReadData(2, "First Name");
                string actualFirstName = SummaryFirstNameText.Text;
                if (!expectedFirstName.Equals(actualFirstName))
                {
                    return false;
                }
                //validate first name
                string expectedLastName = ExcelLib.ReadData(2, "Last Name");
                string actualLastName = SummaryLastNameText.Text;
                if (!expectedLastName.Equals(actualLastName))
                {
                    return false;
                }
                //validate rent start date
                string expectedRentStartDate = ExcelLib.ReadData(2, "Rent Start Date");
                string actualRentStartDate = SummaryRentStartDateText.Text;
                if (!expectedRentStartDate.Equals(actualRentStartDate))
                {
                    return false;
                }
                //validate rent end date
                string expectedRentEndDate = ExcelLib.ReadData(2, "Rent End Date");
                string actualRentEndDate = SummaryRentEndDateText.Text;
                if (!expectedRentEndDate.Equals(actualRentEndDate))
                {
                    return false;
                }

                //validate rent amount
                string expectedRentAmount = ExcelLib.ReadData(2, "Rent Amount");
                string actualRentAmount = SummaryRentAmount.Text;
                if (!expectedRentAmount.Equals(actualRentAmount))
                {
                    return false;
                }

                //validate payment frequency
                string expectedPaymentFrequency = ExcelLib.ReadData(2, "Payment Frequency");
                string actualPaymentFrequency = SummaryPaymentFrequencyText.Text;
                if (!expectedPaymentFrequency.Equals(actualPaymentFrequency))
                {
                    return false;
                }
                //validate payment start date
                string expectedPaymentStartDate = ExcelLib.ReadData(2, "Payment Start Date");
                string actualPaymentStartDate = SummaryPaymentStartDateText.Text;
                if (!expectedPaymentStartDate.Equals(actualPaymentStartDate))
                {
                    return false;
                }

                //validate payment due date
                string expectedPaymentDueDate = ExcelLib.ReadData(2, "Payment Due Date");
                string actualPaymentDueDate = SummaryPaymentDueDateText.Text;
                if (!expectedPaymentDueDate.Equals(actualPaymentDueDate))
                {
                    return false;
                }
                //validate liability name
                string expectedLiabilityName = ExcelLib.ReadData(2, "Liability Name");
                string actualLiabilityName = SummaryLiabilityNameText.Text;
                if (!expectedLiabilityName.Equals(actualLiabilityName))
                {
                    return false;
                }

                //validate amount
                string expectedAmount = ExcelLib.ReadData(2, "Amount");
                string actualAmount = SummaryAmountText.Text;
                if (!expectedAmount.Equals(actualAmount))
                {
                    return false;
                }

            }
            catch(Exception e)
            {
                Console.Write("validate summary data exception" + e);
                return false;
            }

            return true;
        }


    }
    
}
