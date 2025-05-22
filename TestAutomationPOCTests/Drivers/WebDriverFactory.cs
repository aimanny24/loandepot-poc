using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomationPOCTests.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless=new"); // or "--headless"
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            return new ChromeDriver(options);
        }
    }

}
