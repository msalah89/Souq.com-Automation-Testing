Feature: User Login
   I want to check that the user can login in Souq.com .
   
	Scenario Outline: User Login
	Given the user in the souq home page
	When I click on Login link
	And I entered  "<email>" , "<password>" in login "<method>"
	Then My "<name>" should appear beside the cart  
 
 	Examples:
 	| method			| email					   | password	    | name     | 
 	| emailandpassword  | automationroot@gmail.com | reversalizer89 | Mohammed |
 	| facebook			| automationroot@gmail.com | reversalizer89 | Mohammed |
 	| amazon			| automationroot@gmail.com | reversalizer89 | Mohammed |  