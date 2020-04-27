using OpenQA.Selenium;

namespace BBCSeleniumTesting.Lib.pages
{
    public class BbcHomePage
    {
        private IWebDriver _driver;
        private string _homePageUrl = AppConfigReader.BaseUrl;
        private IWebElement SignInButton => this._driver.FindElement(By.Id("idcta-link"));
        public BbcHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void VisitHomePage()
        {
            _driver.Navigate().GoToUrl(_homePageUrl);
        }

        public void ClickSignInLink()
        {
            SignInButton.Click();
        }
    }
}
