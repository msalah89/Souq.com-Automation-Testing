Feature: User SignUp
   I want to check that the user can Signup in Souq.com .
   
	Scenario Outline: User SignUp
	Given the new user in the home page
	When I click on signup link
	And user enter registration data "<firstname>" , "<lastname>" , "<email>" , "<password>" , "<country>" , "<gender>"
	Then My "<username>" should be beside the cart icon 
 
 	Examples:
 	 | Description							| firstname | lastname | email					  | password	   | country | gender | username | 
	 | Succeed Test Case (gender:Male)      | Mohammed  | Salah    | msalah_random@gmail.com  | reversalizer89 | Egypt	 | Male   | Mohammed |
	 | Succeed Test Case (gender:Female)	| Gehad     | Kamal    | Gehad_random@gmail.com   | Hindawi		   | Egypt   | Female | Gehad    |
 	 | Succeed Test Case (country:Bahrain)	| Mohammed  | Salah    | msalah_random@gmail.com  | reversalizer89 | Bahrain | Male   | Mohammed |
