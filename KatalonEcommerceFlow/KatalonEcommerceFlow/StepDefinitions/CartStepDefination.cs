using KatalonEcommerceFlow.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalonEcommerceFlow.StepDefinitions
{
    [Binding]
    public class CartStepDefination
    {
        private ScenarioContext scenarioContext;
        private CartPage cartPage;

        public CartStepDefination(ScenarioContext scenarioContext, CartPage cartPage)
        {
            this.scenarioContext = scenarioContext;
            this.cartPage = cartPage;
        }

        [Then(@"I find total four items listed in my cart")]
        public void ThenIFindTotalFourItemsListedInMyCart()
        {
            Assert.IsTrue(cartPage.IsViewCartPageDisplayed());
            Assert.IsTrue(cartPage.CountOfItemDisplayed()==4);
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            scenarioContext["lowestValue"] = cartPage.GetLowestPriceItem();
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            cartPage.RemoveItem(scenarioContext["lowestValue"]);
        }

        [Then(@"I am able to verify three items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart()
        {
            Assert.IsTrue(cartPage.CountOfItemDisplayed() == 3);
        }







    }
}
