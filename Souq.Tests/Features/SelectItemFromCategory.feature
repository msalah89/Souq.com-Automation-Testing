Feature: Select Category and Item
   make sure that the system open the right selected item  

   
	Scenario Outline: Select Item From Category
	Given the user is in the home page
	When I click on All Categories
	And I choose "<category>" name
	And select "<item>"
	Then I should be in "<item>" page and "<category>" should be mentioned
 
 	Examples:
 	 | category	 | item								       |
	 | Toys      | Dominoes								   |
	 | VR Gadgets| Google Cardboard VR BOX Virtual Reality |
 
