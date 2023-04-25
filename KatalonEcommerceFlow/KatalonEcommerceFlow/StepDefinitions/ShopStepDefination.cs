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
    public class ShopStepDefination
    {
        private ScenarioContext scenarioContext;
        private ShopPage shopPage;

        public ShopStepDefination(ScenarioContext scenarioContext, ShopPage shopPage)
        {
            this.scenarioContext = scenarioContext;
            this.shopPage = shopPage;
        }

        

        [Given(@"User launches the URL '([^']*)'")]
        public void GivenUserLaunchesTheURL(string URL)
        {
            shopPage.NavigateToApllication(URL);
            Assert.IsTrue(shopPage.IsApplicationLaunched());
        }

        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            shopPage.AddFourRandomItemsToMyCart();
          
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            shopPage.ViewMyCart();
           
        }




    }
}
