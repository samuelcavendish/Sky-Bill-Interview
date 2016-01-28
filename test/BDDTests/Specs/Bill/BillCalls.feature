Feature: Bill Calls
	Make sure that the total, count and items are correct for the subscriptions

Scenario: Verify Bill Calls and Values
	Given I am on the bill page
	When I click the call header
	Then the call details should be shown
	And the call total in the header should be hidden
	And there should be 28 call items
	And a total value in the call details of £59.64
		
Scenario: Verify Bill Calls and Values on mobile device
	Given I am on the mobile bill page
	When I click the call header
	Then the call details should be shown
	And the call total in the header should be hidden
	And there should be 28 call items
	And a total value in the call details of £59.64