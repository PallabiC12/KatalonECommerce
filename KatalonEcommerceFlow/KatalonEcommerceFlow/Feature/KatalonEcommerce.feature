﻿Feature: KatalonEcommerce

E2E flow for Katalon Ecommerce Application

@tag1
Scenario: Remove lowest price product from Cart
	Given User launches the URL 'https://cms.demo.katalon.com/'
	And  I add four random items to my cart
	When  I view my cart
	Then   I find total four items listed in my cart
	When  I search for lowest price item
	And  I am able to remove the lowest price item from my cart
	Then  I am able to verify three items in my cart
