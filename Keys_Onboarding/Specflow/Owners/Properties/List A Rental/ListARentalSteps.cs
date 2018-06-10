using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using Keys_Onboarding.Pages.LoginRegister;
using Keys_Onboarding.Pages.OwnerPages.PropertiesForRent;
using Keys_Onboarding.Pages.Owners.Properties;
using Keys_Onboarding.Pages.Owners.Rental_Listings_and_Applications;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Specflow.Owners.Properties.List_A_Rental
{
    [Binding]
    public class ListARentalSteps :Global.Base
    {
        #region background
        [Given(@"I'm already on the list rental property page")]
        public void GivenIMAlreadyOnTheListRentalPropertyPage()
        {
            MyPropertiesPage myProperty = new MyPropertiesPage();
            myProperty.ListARental();
        }
        #endregion

        #region Scenario 1 : Search the rental property after listing 
        [Given(@"I already listed a rental property")]
        public void GivenIAlreadyListedARentalProperty()
        {
            ListRentalPropertyPage obj = new ListRentalPropertyPage();
            obj.AddRentalPropertyDetails();
            obj.SaveListRentalProperty();
            Driver.driver.SwitchTo().Alert().Accept();
        }

        [Given(@"I already under the properties for rent page")]
        public void GivenIAlreadyUnderThePropertiesForRentPage()
        {
            DashboardPage obj = new DashboardPage();
            obj.GotoPropertiesForRentPage();

        }

        [Then(@"I can search this rental property successfully under properties for rent page")]
        public void ThenICanSearchThisRentalPropertySuccessfullyUnderPropertiesForRentPage()
        {
            // Creates a toggle for the given test, adds all log events under it    
            test = extent.CreateTest("List A Rental -- Search the rental property after listing a rental property");

            // Got the search data from excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "List Rental Property");
            String searchPropertyName = ExcelLib.ReadData(2, "Title");

            PropertiesForRent obj = new PropertiesForRent();

            if (obj.SearchRentalPropertySuccessfully(searchPropertyName))

                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed, successfully search new list rental property under properties for rent page");
            else
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test failed, fail to search new list rental property under properties for rent page");

        }
        #endregion 

        #region Scenario 2: Add rental proeprty information and save, pop up a confirmation dialog 
        [When(@"I enter all the rental property information")]
        [Given(@"I already entered all the rental proerty information")]
        public void WhenIEnterAllTheRentalPropertyInformation()
        {
            ListRentalPropertyPage listRentalProperty = new ListRentalPropertyPage();
            listRentalProperty.AddRentalPropertyDetails();

        }

        [When(@"I click save button")]
        [Given(@"I already click save")]
        public void WhenIClickSaveButton()
        {
            ListRentalPropertyPage listRentalProperty = new ListRentalPropertyPage();
            listRentalProperty.SaveListRentalProperty();
        }

        [Then(@"pop up a save confirmation dialog")]
        public void ThenPopUpAConfirmationDialog()
        {
            test = extent.CreateTest("List A Rental -- Add rental proeprty information and save, pop up a confirmation dialog");
            try
            {
                String message = Driver.driver.SwitchTo().Alert().Text;
                test.Log(AventStack.ExtentReports.Status.Pass,"Test passed, sucessfully pop up a confirmation dialog after clicking save button");
            }
            catch (Exception e)
            {
                test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to pop up a confirmation dialog after clicking save button");
            }
        }
        #endregion

        #region Scenarion 3: deal with confirmation dialog and confirm to list
        [When(@"I click ok button in the confirmation dialog")]
        public void WhenIClickOkButtonInTheConfirmationDialog()
        {
            Thread.Sleep(4000);
            Driver.driver.SwitchTo().Alert().Accept();
        }

        [Then(@"I'm navigated to the rental listings&applications page")]
        public void ThenIMNavigatedToTheRentalListingsApplicationsPage()
        {
            test = extent.CreateTest("List A Rental -- deal with confirmation dialog and confirm to list");
            RentalListingsAndTenantApplications obj = new RentalListingsAndTenantApplications();
            
            if(obj.IsHeaderDisplayed())
            {
                test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully navigate to rental listings&applications page");
            }
            else
            {
                test.Log(AventStack.ExtentReports.Status.Fail , "Test failed, fail to navigate to rental listings&applications page");

            }
        }

        #endregion

        #region Scenario 4: deal with confirmation dialog and cancel to list
        [When(@"I click cancel button in the confirmation dialog")]
        public void WhenIClikcCancelButtonInTheConfirmationDialog()
        {
            Driver.driver.SwitchTo().Alert().Dismiss();
        }

        [Then(@"I stay at list rental property page")]
        public void ThenIStayAtListRentalPropertyPage()
        {
            test = extent.CreateTest("List A Rental -- deal with confirmation dialog and cancel to list");
            ListRentalPropertyPage obj = new ListRentalPropertyPage();

            if (obj.IsHeaderDisplayed())
            {
                test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, succesfully stay at list rental property page");
            }
            else
            {
                test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to stay at list rental property page");

            }
        }

        #endregion

        #region Scenario 5: cancel list rental property and pop up a confirmation dialog

        [When(@"I click cancel button")]
        [Given(@"I already clicked the cancel button")]
        public void WhenIClickCancelButton()
        {
            ListRentalPropertyPage obj = new ListRentalPropertyPage();
            obj.CancelListRentalProperty();
        }

        [Then(@"pop up a cancel confirmation dialog")]
        public void ThenPopUpACancelConfirmationDialog()
        {
            test = extent.CreateTest("List A Rental -- cancel list rental property and pop up a confirmation dialog");

            ListRentalPropertyPage obj = new ListRentalPropertyPage();

            if(obj.IsConfirmationDialogDisplay())
            { 
                test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, sucessfully pop up a confirmation dialog after clicking cancel button");
            }
            else
            {
                test.Log(AventStack.ExtentReports.Status.Fail, "Test failed, fail to pop up a confirmation dialog after clicking cancel button");
            }
        }
        #endregion

        #region Scenario 6: Deal with confirmation dialog and confirm to cancel

        [When(@"I click the yes button")]
        public void WhenIClickTheYesButton()
        {
            ListRentalPropertyPage obj = new ListRentalPropertyPage();
            obj.ConfirmToCancel();
        }

        [Then(@"I'm navigated to my properties page")]
        public void ThenIMNavigatedToMyPropertiesPage()
        {
            test = extent.CreateTest("List A Rental -- Deal with confirmation dialog and confirm to cancel");

            MyPropertiesPage obj = new MyPropertiesPage();
            if (obj.IsAddNewPropertyButtonDisplayed())
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully navigate to my properties page after confirm cancel");
            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test falied, fail to navigate to my properties page after confirm cancel");
            }
        }

        #endregion

        #region Scenario 7:  Deal with confirmation dialog and quit to cancel

        [When(@"I click the no button")]
        public void WhenIClickTheNoButton()
        {
            ListRentalPropertyPage obj = new ListRentalPropertyPage();
            obj.QuitToCancel();
        }

        #endregion
    }
}
