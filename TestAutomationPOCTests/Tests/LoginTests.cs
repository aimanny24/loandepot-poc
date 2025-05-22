using OpenQA.Selenium;
using TestAutomationPOCTests.Drivers;
using TestAutomationPOCTests.Pages;

namespace TestAutomationPOCTests.Tests
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = WebDriverFactory.CreateChromeDriver();
            _loginPage = new LoginPage(_driver);
        }

        [Test]
        public void Login_WithValidCredentials_ShouldNavigateToDashboard()
        {
            _loginPage.NavigateTo("https://localhost:44354"); // change port if different
            System.Threading.Thread.Sleep(2000); 
            _loginPage.EnterUsername("admin");
            System.Threading.Thread.Sleep(2000); 

            _loginPage.EnterPassword("password123");
            System.Threading.Thread.Sleep(2000); 

            _loginPage.ClickLogin();
            System.Threading.Thread.Sleep(2000); 

            Assert.IsTrue(_driver.PageSource.Contains("Welcome to the Dashboard"));
            Assert.IsTrue(_driver.PageSource.Contains("You are successfully logged in!"));
            System.Threading.Thread.Sleep(5000);

            // After navigation, before finding the element
            System.IO.File.WriteAllText("page.html", _driver.PageSource);
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("screenshot.png");
        }

        [Test]
        public void Login_WithInvalidCredentials_ShouldShowErrorMessage()
        {
            _loginPage.NavigateTo("https://localhost:44354");
            System.Threading.Thread.Sleep(2000);

            _loginPage.EnterUsername("wrong");
            System.Threading.Thread.Sleep(2000);

            _loginPage.EnterPassword("user");
            System.Threading.Thread.Sleep(2000);

            _loginPage.ClickLogin();
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(_loginPage.GetErrorMessage().Contains("Invalid username or password."));

            // After navigation, before finding the element
            System.IO.File.WriteAllText("page.html", _driver.PageSource);
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile("screenshot.png");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
