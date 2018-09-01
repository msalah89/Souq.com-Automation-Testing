Feature: User ForgetPassword
   I want to check that the user can recover his password
   
	Scenario Outline: User Recover Password
	Given the user at the home page
	When I click on forgetpassword Page
	And I entered "<email>" 
	Then Check for password recovery email with "<email>" and "<password>" 
	And Enter new password "<password>"
	Then  "<username>" should appear at top right
 
 	Examples:
 	  |email					       | password	    |username|
	  | automationroot@gmail.com       |reversalizer89  |Mohammed|
 	  