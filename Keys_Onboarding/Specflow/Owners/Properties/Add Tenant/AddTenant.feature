Feature: AddTenant

Background: 
	Given I have logged into the application 
		And I'm already under the Add Tenant Page of a given property

@mytag
Scenario: Add tenant details and go to liabilities details
	When I enter all the tenant details with valid data under tenant details section
		And I click next button under tenant details section
	Then I'am navigated to liability details 

Scenario: Add an existing tenant under tenant details section
	When I enter an existing tenant email of this property 
	Then There should be warning message and he Next button should be unclickable

Scenario: Add new liability details under liabilities details section
	Given I am already under the liabilities details section
	When I click add new liability button
		And  I enter new liability detail
		And I click save new liability button
	Then  The new liability should be added successfully

Scenario: Add liability details and go to summary section
	Given I am already under the liabilities details section
		And I have added a new liability
	When I click next button under liabilities details 
	Then I'm navigated to the summary 

Scenario: Check all the information under summary section
	Given I am already under the summary section
	Then All the inforamtion should be the same as what I entered in tenant details and liabilities details

Scenario: Submit all the information under summary section
	Given I am already under the summary section
	When I click submit button under summary
	Then I'm navigated to my properties page from Add Tenant Page

Scenario: Search this new tenant under manage tenant page after adding new tenant
	Given I have added a new tenant for a given property and went back to My Properties Page
	When I search this property in the property list
		And I click Manage Tenant button and go to Manage Tenant page 
	Then I find this new tenant

