Feature: TMFeature

A short summary of the feature
// 3 test cases

@tag1
Scenario: Create time and material record with valid details
	Given I logged into turn up portal successfully
	When I navigate to time and material page
	And I create a new time and material record
	Then The record should be create successfully


Scenario Outline: Edit time and material record with valid datails
	Given I logged into turn up portal successfully
	When I navigate to time and material page
	And I update '<Description>', '<Code>' and '<Price>' on an existing time and material record
	Then The record should have the updated '<Description>', '<Code>' and '<Price>'

Examples:
	| Description | Code     | Price   |
	| Time        | Snack    | $5.00   |
	| Edited      | Keyboard | $300.00 |
	| Updated     | Computer | $3000.00|

