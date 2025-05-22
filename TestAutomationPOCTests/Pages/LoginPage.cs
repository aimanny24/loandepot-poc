using OpenQA.Selenium;

namespace TestAutomationPOCTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameField = By.Name("username");
        private readonly By passwordField = By.Name("password");
        private readonly By loginButton = By.CssSelector("button[type='submit']");
        private readonly By errorMessage = By.CssSelector("div[style*='color: red']");

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void NavigateTo(string url) => Driver.Navigate().GoToUrl(url);

        public void EnterUsername(string username) =>
        Driver.FindElement(usernameField).SendKeys(username);

        public void EnterPassword(string password) =>
        Driver.FindElement(passwordField).SendKeys(password);

        public void ClickLogin() => Driver.FindElement(loginButton).Click();

        public string GetErrorMessage() => Driver.FindElement(errorMessage).Text;
    }

}
