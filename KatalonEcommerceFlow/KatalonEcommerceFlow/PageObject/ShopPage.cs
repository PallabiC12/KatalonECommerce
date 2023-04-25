using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalonEcommerceFlow.PageObject
{
    public class ShopPage: BasePage
    {
        private BasePage basePage;
        private IWebDriver driver;

        public ShopPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            basePage = new BasePage(driver);
        }
        #region PageObject
        private IWebElement Header => driver.FindElement(By.XPath(".//a[normalize-space(.)='Katalon Shop']"));     
        private IEnumerable<IWebElement> AddToCart => driver.FindElements(By.XPath(".//a[normalize-space(.)='Add to cart']"));
        private IWebElement ViewCart => driver.FindElement(By.XPath(".//a[normalize-space(.)='Cart']"));
        

        #endregion

        #region Method
        public void NavigateToApllication(string URL)
        {
            driver.Url = URL;
        }

        public bool? IsApplicationLaunched()
        {
            return IsDisplayed(Header);
        }

        public void AddFourRandomItemsToMyCart()
        {
            var Counter = 0;
            foreach (var item in AddToCart)
            {
                ClickElement(item);                 
                Counter++;
                if(Counter == 4)
                {
                    break;
                }
            }
        }

        public void ViewMyCart()
        {
            ClickElement(ViewCart);
        }

        
        #endregion
    }
}
