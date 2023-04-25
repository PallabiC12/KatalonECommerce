
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace KatalonEcommerceFlow.Hook
{
    [Binding]
    public sealed class Hook
    {
        IWebDriver driver;
        IObjectContainer container;

        public Hook(IObjectContainer container)
        {
           
            this.container = container;
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}