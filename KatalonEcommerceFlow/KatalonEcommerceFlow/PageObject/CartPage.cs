using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalonEcommerceFlow.PageObject
{
    public class CartPage: BasePage
    {
        private BasePage basePage;
        private IWebDriver driver;

        public CartPage(IWebDriver driver) : base(driver)
        {

            this.driver = driver;
            basePage = new BasePage(driver);
        }

        #region PageObject
        private IWebElement ViewCartHeader => driver.FindElement(By.XPath(".//a[normalize-space(.)='Cart']"));

        private IEnumerable<IWebElement> AddedItemsInCart => driver.FindElements(By.XPath(".//a[contains(@href,'product') and not(text()) and not(@class)]"));

        private IWebElement CartTable => driver.FindElement(By.XPath(".//table[contains(@class,'shop_table shop_table_responsive cart')]/tbody"));

       
        

        #endregion



        #region Method
        public int CountOfItemDisplayed()
        {
            return AddedItemsInCart.Count();    
        }

        public bool? IsViewCartPageDisplayed()
        {
            return IsDisplayed(ViewCartHeader);
        }

        public string GetLowestPriceItem()
        {
            IList<IWebElement> RowElementList = CartTable.FindElements(By.XPath(".//*[@class='woocommerce-cart-form__cart-item cart_item']"));

            var ListVal = new List<int>();
            foreach (IWebElement row in RowElementList)
            {
                ListVal.Add(Int32.Parse(row.FindElements(By.TagName("td"))[3].Text.Replace('$', ' ').Split(".")[0]));
                
            }

            var Min = ListVal.Min();
            var MinObject = ".//*[contains(text(), '"+Min+ "')]/parent::*/preceding-sibling::*//a[@class='remove']";
            return MinObject;
            }

        public void RemoveItem(Object value)
        {
            var element = FindElement(By.XPath(value.ToString()));
            ClickElement(element);
        }

    }



    #endregion

}
