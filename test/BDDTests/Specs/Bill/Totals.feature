Feature: Totals
	Check the totals and dates

Scenario: Check the totals
	Given I am on the bill page
	Then the Bill from date should be 26 Jan 2015
	And the Bill to date should be 25 Feb 2015
	And the Subscription total should equal £71.40	
	And the Calls total should equal £59.64
	And the Store Purchases total should equal £24.97
	#Testing for the total due as it's being returned rather than the sum
	And the Total Due should be £136.03
	And the statement date should be 11 Jan 2015
		
Scenario: Check the totals on mobile device
	Given I am on the mobile bill page
	Then the Bill from date should be 26 Jan 2015
	And the Bill to date should be 25 Feb 2015
	And the Subscription total should equal £71.40	
	And the Calls total should equal £59.64
	And the Store Purchases total should equal £24.97
	#Testing for the total due as it's being returned rather than the sum
	And the Total Due should be £136.03
	And the statement date should be 11 Jan 2015