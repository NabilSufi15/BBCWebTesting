using OpenQA.Selenium;

namespace BBCSeleniumTesting.Lib.pages
{
    public class BbcLoginPage
    {
        private IWebDriver _driver;
        private string _loginPageUrl = AppConfigReader.SignInPageUrl;
        private IWebElement UsernameField => _driver.FindElement(By.Id("user-identifier-input"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password-input"));
        private IWebElement SubmitButton => _driver.FindElement(By.Id("submit-button"));
        private IWebElement UserNameError => _driver.FindElement(By.Id("form-message-username"));
        private IWebElement PasswordError => _driver.FindElement(By.Id("form-message-password"));
        public BbcLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void VisitLoginPage()
        {
            _driver.Navigate().GoToUrl(_loginPageUrl);
        }

        public void InputUserName(string username)
        {
            UsernameField.SendKeys(username);
        }
        public void InputPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        public void ClickSubmit()
        {
            SubmitButton.Click();
        }

        public string GetUserNameErrorText()
        {
            return UserNameError.Text;
        }

        public string GetPasswordErrorText()
        {
            return PasswordError.Text;
        }
    }
}
