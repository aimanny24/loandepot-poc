using OpenQA.Selenium;

namespace TestAutomationPOCTests.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }

}
