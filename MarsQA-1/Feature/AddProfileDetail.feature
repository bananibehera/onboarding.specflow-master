Feature: Add Profile Details
        As a seller
       I would like to add my profile details
	   so that people seeking for skills can look into my details

@AddEditDeleteLanguage
Scenario: Add New langauge in the profile detail page
	Given I login to the website with valid credential
	When I try to add new language on the profile page
	Then Seller should able to add new language successfully

Scenario: Delete new Seller Language Details on profile page
	When I try to delete existing language
	Then Seller able to delete existing language successfully

Scenario: Add the education details
	Given I login to the website with valid credential
	When I add education details '<Year>','<Country>','<Title>'
	Then I should be able to add education details successfully
	Examples:
	|  Year      | Country     | Title |
	| 2009       | New Zealand | B.Tech |

Scenario: Update the education details
	Given I login to the website with valid credential
	When I update the education detail'<Title>'
	Then I should be able to update the education detail successfully
	Examples:
	| Title |
	| M.Tech |



	











