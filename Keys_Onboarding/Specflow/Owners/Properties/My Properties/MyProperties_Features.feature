Feature: PropertyOwner_Features

Background:
	Given I have logged into the application
	Given  I'm already on the My Properties Page 

Scenario: Search for a property under Properties Page
	Then the search result for this property is right
