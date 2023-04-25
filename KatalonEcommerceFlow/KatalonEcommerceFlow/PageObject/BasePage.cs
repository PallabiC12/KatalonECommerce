using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KatalonEcommerceFlow.PageObject
{
    public class BasePage
    {
        IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By elementlocator, int timeOutInSeconds=30) {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(drv => drv.FindElement(elementlocator));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By elementlocator, int timeOutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            var elements =  wait.Until(drv => driver.FindElements(elementlocator));
            return elements;
        }
        

        public void ClickElement(IWebElement element) {
            element.Click();
            Thread.Sleep(1000);
        }

        public Boolean IsDisplayed(IWebElement element) {
            return element.Displayed;
        }

        public void MouseOverElement(IWebElement ele)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ele).Perform();
        }


    }
}
