Feature: Bill Store
	Make sure that the total, count and items are correct for the subscriptions

Scenario: Verify Bill Store and Values
	Given I am on the bill page
	When I click the store header
	Then the store details should be shown
	And the store total in the header should be hidden
	And there should be 1 store rental item
	And 2 buy and keep items
	And a total value in the store details of £24.97
		
Scenario: Verify Bill Store and Values on mobile device
	Given I am on the mobile bill page
	When I click the store header
	Then the store details should be shown
	And the store total in the header should be hidden
	And there should be 1 store rental item
	And 2 buy and keep items
	And a total value in the store details of £24.97