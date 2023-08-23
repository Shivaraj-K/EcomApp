Feature: Placing an Order on the eCommerce Website



Scenario: Add and Placing an Order

	Given The user is on the eCommerce website
	
	When The User is login to eCommerce Application
	| UserName               | Password |
	| specflow1234@gmail.com | Specflow@1234 |
	And The user select The product "IPHONE" and adds it to the cart
    And proceeds to checkout 
	And Select country wirh ShortName "ind" and places the order
	Then the user should see an order confirmation with the Msg is "THANKYOU FOR THE ORDER."

