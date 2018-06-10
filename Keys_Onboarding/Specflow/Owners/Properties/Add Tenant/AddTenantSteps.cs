using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using Keys_Onboarding.Pages.Owners.Properties;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Specflow.Owners.Properties.Add_Tenant
{
    [Binding]
    public class AddTenantSteps :Base
    {
        #region background

        [Given(@"I'm already under the Add Tenant Page of a given property")]
        public void GivenIMAlreadyUnderTheAddTenantPageOfAGivenProeprty()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            String propertyName = ExcelLib.ReadData(2, "Property Name");
            String tenantEmail = ExcelLib.ReadData(2, "Tenant Email");

            //go to my properties page from dashboard
            DashboardPage dashBoard = new DashboardPage();
            dashBoard.GoToMyPropertiesPage();

            //search a property
            MyPropertiesPage myProperty = new MyPropertiesPage();
            myProperty.SearchAPropertySuccessfully(propertyName);

            //go to manage tenant page and delete the tenant which user want to add
            myProperty.GoToManageTenantPage();
            ManageTenantPage manageTenant = new ManageTenantPage();
            manageTenant.RemoveTenant(tenantEmail);

            //go back to my properties page and then go to add tenant page
            manageTenant.GoBackToProperties();
            myProperty.AddTenant();
        }

        #endregion

        #region Scenarion 1: Add tenant details and go to liabilities details

        [When(@"I enter all the tenant details with valid data under tenant details section")]
        public void WhenIEnterAllTheTenantDetailsWithValidDataUnderTenantDetailsSection()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.AddTenantDetails();
        }

        [When(@"I click next button under tenant details section")]
        public void WhenIClickNextButtonUnderTenantDetailsSection()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.NextToLiabilityDetails();

        }

        [Then(@"I'am navigated to liability details")]
        public void ThenIAmNavigatedToLiabilityDetails()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.CreateTest("Add Tenant -- Add tenant details and go to liabilities details");
            test.AssignCategory("Add Tenant Testing");

            // Create an class and object to call the method
            AddTenantPage addTenant = new AddTenantPage();

            if (addTenant.IsAddNewLiabilityButtonDisplay())

                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully navigated to liability details ");

            else
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to navigate to liability details ");

            Thread.Sleep(6000);

        }

        #endregion

        #region Scenario 2: Add an existing tenant under tenant details section

        [When(@"I enter an existing tenant email of this property")]
        public void WhenIEnterAnExistingTenantEmailOfThisProperty()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.AddExistingTenantDetails();

        }

        [Then(@"There should be warning message and he Next button should be unclickable")]
        public void ThenThereShouldBeWarningMessageAndHeNextButtonShouldBeUnclickable()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.CreateTest("Add Tenant -- Add an existing tenant under tenant details section");
            test.AssignCategory("Add Tenant Testing");

            AddTenantPage addTenant = new AddTenantPage();
            if (addTenant.IsTenantAlreadyInThisPropertyWarningMessageDisplayed() & addTenant.IsNextButtonUnclickableUnderTenatDetails())
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully display the warning message and next button is unclickable");

            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to display the warning message or next button is clickable");

            }
        }

     
        #endregion

        #region Scenario 3: Add new liability details under liabilities details section

        [Given(@"I am already under the liabilities details section")]
        public void GivenIAmAlreadyUnderTheLiabilitiesDetailsSection()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.AddTenantDetails();
            addTenant.NextToLiabilityDetails();
        }

        [When(@"I click add new liability button")]
        public void WhenIClickAddNewLiabilityButton()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.ClickAddNewLiability();

        }

        [When(@"I enter new liability detail")]
        public void WhenIEnterNewLiabilityDetail()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.AddLiabilityDetails();
        }

        [When(@"I click save new liability button")]
        public void WhenIClickSaveNewLiabilityButton()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.SaveNewLiability();
        }

        [Then(@"The new liability should be added successfully")]
        public void ThenTheNewLiabilityShouldBeAddedSuccessfully()
        {
            test = extent.CreateTest("Add Tenant -- Add new liability details under liabilities details section");
            test.AssignCategory("Add Tenant Testing");

            //get the liability name and amount from excel file
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            String liabilityName = ExcelLib.ReadData(2, "Liability Name");
            String amount = ExcelLib.ReadData(2, "Amount");

            AddTenantPage addTenant = new AddTenantPage();
            if(addTenant.FindLiabilitySuccessfully(liabilityName,amount))
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully add new liability");
            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to add new liability");

            }

            Thread.Sleep(6000);
        }
        #endregion 

        #region Scenario 4: Add liability details and go to summary section
        [Given(@"I have added a new liability")]
        public void GivenIHaveAddedANewLiability()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.ClickAddNewLiability();
            addTenant.AddLiabilityDetails();
            addTenant.SaveNewLiability();
        }

        [When(@"I click next button under liabilities details")]
        public void WhenIClickNextButtonUnderLiabilitiesDetails()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.NextToSummary();
        }

        [Then(@"I'm navigated to the summary")]
        public void ThenIMNavigatedToTheSummary()
        {
            test = extent.CreateTest("Add Tenant -- Add liability details and go to summary section");
            test.AssignCategory("Add Tenant Testing");

            AddTenantPage addTenant = new AddTenantPage();
            if(addTenant.IsSubmitButtonDisplay())
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully navigate to the summary ");

            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to navigate to the summary ");

            }
        }
        #endregion

        #region Scenario 5: Check all the information under summary section
        [Given(@"I am already under the summary section")]
        public void GivenIAmAlreadyUnderTheSummarySection()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.AddTenantDetails();
            addTenant.NextToLiabilityDetails();
            addTenant.ClickAddNewLiability();
            addTenant.AddLiabilityDetails();
            addTenant.NextToSummary();

        }

        [Then(@"All the inforamtion should be the same as what I entered in tenant details and liabilities details")]
        public void ThenAllTheInforamtionShouldBeTheSameAsWhatIEnteredInTenantDetailsAndLiabilitiesDetails()
        {
            test = extent.CreateTest("Add Tenant -- Check all the information under summary section");
            test.AssignCategory("Add Tenant Testing");

            AddTenantPage addTenant = new AddTenantPage();
            if(addTenant.ValidateDataInSummary())
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "test passed, successfully validate all the inforamtion in summary");
            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "test failed, fail to validate all the inforamtion in summary");

            }
        }

        #endregion

        #region Scenario 6: Submit all the information under summary section
        [When(@"I click submit button under summary")]
        public void WhenIClickSubmitButtonUnderSummary()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.Submit();
        }

        [Then(@"I'm navigated to my properties page from Add Tenant Page")]
        public void ThenIMNavigatedToMyPropertiesPageFromAddTenantPage()
        {
            test = extent.CreateTest("Add Tenant -- Submit all the information under summary section");
            test.AssignCategory("Add Tenant Testing");

            MyPropertiesPage propertyOwner = new MyPropertiesPage();

            if (propertyOwner.IsMyPropertiesPageHeaderVisible())
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully navigated to my properties page from Add Tenant Page");
            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test falied, fail navigated to my properties page from Add Tenant Page");
            }
        }

        #endregion

        #region Scenario 7: Search this new tenant under manage tenant page after adding new tenant

        [Given(@"I have added a new tenant for a given property and went back to My Properties Page")]
        public void GivenIHaveAddedANewTenantForAGivenPropertyAndWentBackToMyPropertiesPage()
        {
            AddTenantPage addTenant = new AddTenantPage();
            addTenant.AddTenantDetails();
            addTenant.NextToLiabilityDetails();
            addTenant.ClickAddNewLiability();
            addTenant.AddLiabilityDetails();
            addTenant.NextToSummary();
            addTenant.Submit();
        }

        [When(@"I search this property in the property list")]
        public void WhenISearchThisPropertyInThePropertyList()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            String propertyName = ExcelLib.ReadData(2, "Property Name");

            MyPropertiesPage myProperty = new MyPropertiesPage();
            myProperty.SearchAPropertySuccessfully(propertyName);
        }

        [When(@"I click Manage Tenant button and go to Manage Tenant page")]
        public void WhenIClickManageTenantButtonAndGoToManageTenantPage()
        {
            MyPropertiesPage myProperty = new MyPropertiesPage();
            myProperty.GoToManageTenantPage();
        }

        [Then(@"I find this new tenant")]
        public void ThenIFindThisNewTenant()
        {
            test = extent.CreateTest("Add Tenant -- Search this new tenant under manage tenant page after adding new tenant");
            test.AssignCategory("Add Tenant Testing");

            ExcelLib.PopulateInCollection(Base.ExcelPath, "Add Tenant");
            String email = ExcelLib.ReadData(2, "Tenant Email");

            ManageTenantPage manageTenant = new ManageTenantPage();
            if(manageTenant.FindATenant(email))
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully find the new tenant");

            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to find the new tenant");

            }
        }
        #endregion
    }
}
