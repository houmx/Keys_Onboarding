using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using Keys_Onboarding.Pages.Owners.Properties;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Specflow.Owners.Properties.Add_New_Property
{
    [Binding]
    public class AddNewPropertySteps : Global.Base
    {
        #region Background

        [Given(@"I'm already on the Add New Property Page")]
        [Given(@"I'm already on the Property Details Section")]
        public void GivenIMAlreadyOnTheAddNewPropertyPage()
        {
            DashboardPage dashBoard = new DashboardPage();
            dashBoard.GoToMyPropertiesPage();
            MyPropertiesPage myProperties = new MyPropertiesPage();
            myProperties.AddNewProperty();
        }

        #endregion

        #region  Scenario 1: Add property details and go to Finance Details Section

        [When(@"I enter all the property details")]
        public void WhenIEnterAllThePropertyDetails()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.AddPropertyDetails();
        }
        
        [When(@"click next button on Property Details Section")]
        public void WhenClickNextButton()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.GotoFinanceForm();
        }
    
        [Then(@"I'm navigated to the Finace Details Section")]
        public void ThenIMNavigatedToTheFinaceDetailsSection()
        {

            try
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.CreateTest("Add New Property -- fill out property details form and go to Finance Details Section ");
                test.AssignCategory("Add New Property Testing");

                // Create an class and object to call the method
                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();

                if (addNewProperty.IsFianceFormHeaderDisplayed())

                    Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, go to Fiance Details Section successfull");

                else
                    Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go to Fiance Details Section unsuccessfull");

            }
            catch (Exception e)
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go to Fiance Details Section unsuccessfull" + e.Message);
            }

        }
        #endregion

        #region  Secnario 2: Cancel add property under Property Details Section

        [When(@"I click cancel button on Property Details Section")]
        public void WhenIClickCancelButtonOnPropertyDetailsSection()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.CancelPropertyForm();
        }

        [Then(@"popup an confirmation dialog")]
        public void ThenPopupAnConfirmationDialog()
        {
            try
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.CreateTest("Add New Property -- Cancel add property under Property Details Section");

                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();

                if (addNewProperty.IsCancelConfirmationDialogDisplayed())

                    Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, pop up confirmation dialog successfully");

                else
                    Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, pop up confirmation dialog unsuccessfull");

            }
            catch (Exception e)
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, pop up confirmation dialog unsuccessfull" + e.Message);
            }

        }

        #endregion

        #region Scenario 3: Add finance details and go to Tenant Details Section

        [Given(@"I'm already on the Finance Details Section")]
        public void GivenIMAlreadyOnTheFinanceDetailsSection()
        {

            //Go to Finance Section 
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.AddPropertyDetails();
            addNewProperty.GotoFinanceForm();
        }

        [When(@"I enter all the finance details")]
        public void WhenIEnterAllTheFinanceDetails()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.AddFinanceDetails();
        }

        [When(@"click next button on the Finance Details Section")]
        public void WhenClickNextButtonOnTheFinanceDetailsSection()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.GotoTenantForm();
        }

        [Then(@"I'm navigated to the Tenant Details Section")]
        public void ThenIMNavigatedToTheTenantDetailsSection()
        {
            try
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.CreateTest("Add New Property -- fill out finance details form and go to Tenant Details Section");

                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();

                if (addNewProperty.IsTenantFormHeaderDisplayed())

                    Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, go to Tenant Details Section successfully");

                else
                    Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go to Tenant Details Section unsuccessfull");

            }
            catch (Exception e)
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go to Tenant Details Section unsuccessfull" + e.Message);
            }
        }

        #endregion

        #region Scenario 4: Cancel add property under Finace Details Section

        [When(@"I click cancel button on Finance Details Section")]
        public void WhenIClickCancelButtonOnFinanceDetailsSection()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.CanceFianceForm();
        }

        #endregion

        #region Scenario 5: Go back to Property Details Section

        [When(@"I click previous button on the Finace Details Section")]
        public void WhenIClickPreviousButtonOnTheFinaceDetailsSection()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.GoBackToPropertyForm();
        }

        [Then(@"I go back to the Property Details Section")]
        public void TheniGoBackToThePropertyDetailsSection()
        {
            try
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.CreateTest("Add New Property -- Go back to Property Details Section");

                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
                if(addNewProperty.IsPropertyFormHeaderDisplayed())
                {
                    Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, go back to Property Details Section successfull");
                }
                else
                {
                    Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go back to Property Details Section unsuccessfull");
                }

            }
            catch(Exception e)
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go back to Property Details Section unsuccessfull" + e.Message);
            }

        }

        #endregion

        #region Scenario 6: Add tenant details and save all information

        [Given(@"I'm already on the Tenant Details Section")]
        public void GivenIMAlreadyOnTheTenantDetailsSection()
        {
            //Go to Finance Section 
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.AddPropertyDetails();
            addNewProperty.GotoFinanceForm();

            //Go to Tenant Section
            addNewProperty.AddFinanceDetails();
            addNewProperty.GotoTenantForm();
        }

        [When(@"I enter all the tenant details")]
        public void WhenIEnterAllTheTenantDetails()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.AddTenantDetails();
        }

        [When(@"click save button")]
        public void WhenClickSaveButton()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.SaveProperty();
        }

        [Then(@"new property is added successfully and I'm navigated to the Property Owner Page")]
        public void ThenNewPropertyIsAddedSuccessfullyAndIMNavigatedToThePropertyOwnerPage()
        {
           try
            {
                test = extent.CreateTest("Add New Property -- fill out tenant details form and save all information");
                MyPropertiesPage propertyOwner = new MyPropertiesPage();

                if (propertyOwner.IsAddNewPropertyButtonDisplayed())
                {
                    Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, save all the information successfull");
                }
                else
                {
                    Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test falied, save all the information unsuccessfull");
                }
            }
            catch(Exception e)
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, sace all the information unsuccessfull");
            }

        }

        #endregion

        #region Scenario 7: Cancel add property under Tenant Details Section

        [When(@"I click cancel button on the Tenant Details Section")]
        public void WhenIClickCancelButtonOnTheTenantDetailsSection()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.CanceTenantForm();
        }

        #endregion

        #region Scenario 8: Go back to Finace Details Section

        [When(@"I click previous button on the Tenant Details Section")]
        public void WhenIClickPreviousButtonOnTheTenantDetailsSection()
        {
            Thread.Sleep(3000);
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.GoBackToFianceForm();
        }

        [Then(@"I go back to the Finace Details Section")]
        public void ThenIGoBackToTheFinaceDetailsSection()
        {
            try
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.CreateTest("Add New Property -- Go back to Finance Details Section");

                AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
                if (addNewProperty.IsFianceFormHeaderDisplayed())
                {
                    Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, go back to Finance Details Section successfull");
                }
                else
                {
                    Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go back to Finance Details Section unsuccessfull");
                }

            }
            catch (Exception e)
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, go back to Finance Details Section unsuccessfull" + e.Message);
            }

        }

        #endregion

        #region Scenario 9: Search the new property user added under Properties Page

        [Given(@"I have added a new property")]
        public void GivenIHaveAddedANewProperty()
        {
            AddNewPropertyPage addNewProperty = new AddNewPropertyPage();
            addNewProperty.AddPropertyDetails();
            addNewProperty.GotoFinanceForm();
            addNewProperty.AddFinanceDetails();
            addNewProperty.GotoTenantForm();
            addNewProperty.AddTenantDetails();
            addNewProperty.SaveProperty();
        }

        [Given(@"I search this property under Properties Page")]
        public void GivenISearchThisPropertyUnderPropertiesPage()
        {
            // Got the search data from excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Property Details");
            String searchPropertyName = ExcelLib.ReadData(2, "Property Name");

            MyPropertiesPage propertyOwner = new MyPropertiesPage();
            propertyOwner.SearchAPropertySuccessfully(searchPropertyName);
        }
        #endregion

        #region Scenario 10: Search for the new property user added under Properties Page

        [When(@"I click the first searching result")]
        public void WhenIClickTheFirstSearchingResult()
        {
            MyPropertiesPage myProperty = new MyPropertiesPage();
            myProperty.ClickFirstPorpertyNameInList();
        }

        [Then(@"The property details information is the same as I added")]
        public void ThenThePropertyDetailsInformationIsTheSameAsIAdded()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.CreateTest("Add New Property --  Validate property details of search result under Properties Page");

            PropertyDetailsPage propertyDetails = new PropertyDetailsPage();
            int tenantNum = propertyDetails.GetTenantNumber();
            int newrequestNun = propertyDetails.GetNewRequestNumber();
            int maintanceNum = propertyDetails.GetMaintanceNumber();
            int paymentNum = propertyDetails.GetPaymentNumber();

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Property Details");
            String ExpectBedroomNum = ExcelLib.ReadData(2, "Bedrooms");
            String ExpectBathroomNum = ExcelLib.ReadData(2, "Bathrooms");
            String ExpectCarparkNum = ExcelLib.ReadData(2, "Carparks");

            string ActualBedroomNum = propertyDetails.GetBedroomNumber();
            string ActualBathroomNum = propertyDetails.GetBathroomNumber();
            string ActualCarparkNum = propertyDetails.GetCarparkNumber();

            if(tenantNum==1 & newrequestNun==0 & maintanceNum==0 &paymentNum==0 & ActualBedroomNum.Equals(ExpectBedroomNum) & ActualBathroomNum.Equals(ExpectBathroomNum) & ActualCarparkNum.Equals(ExpectCarparkNum) )
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, The property details information is the same as I added");
            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, The property details information is not the same as I added");
            }

        }

        #endregion


    }
}
