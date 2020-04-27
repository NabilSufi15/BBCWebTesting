using NUnit.Framework;
using BBCSeleniumTesting.Lib;

namespace BBCSeleniumTesting.Tests
{
    [TestFixture]
    public class WebpageLoginTests
    {
        // Instantiate the page objects, include all functionality for the web pages
        // will see that later
        public BbcWebsite BbcWebsite;

        [TestCase("1234567", "Sorry, that password is too short. It needs to be eight characters or more.")]
        [TestCase("12345678", "Sorry, that password isn't valid. Please include a letter.")]
        [TestCase("", "Something's missing. Please check and try again.")]
        [TestCase("ghvhjvjhhhv", "Sorry, that password isn't valid. Please include something that isn't a letter.")]
        [Test]
        public void InvalidPasswordTest(string password, string expMsg)
        {
            // set up driver and page model
            BbcWebsite = new BbcWebsite("chrome");
            // go to the BBC home page
            BbcWebsite.bbcHomePage.VisitHomePage();
            // click sign in link
            BbcWebsite.bbcHomePage.ClickSignInLink();
            // enter a username
            BbcWebsite.bbcLoginPage.InputUserName("JohnDoe@home.com");
            // enter a password
            BbcWebsite.bbcLoginPage.InputPassword(password);
            // click the signin button
            BbcWebsite.bbcLoginPage.ClickSubmit();
            // check the error is correct
            Assert.That(BbcWebsite.bbcLoginPage.GetPasswordErrorText, Is.EqualTo(expMsg));
        }

        [TestCase("", "Something's missing. Please check and try again.")]
        [TestCase("JohnDoe@home.com", "Sorry, we can’t find an account with that email. You can register for a new account or get help here.")]
        [Test]
        public void UsernameErrorMessage(string user, string expMsg)
        {
            // set up driver and page model
            BbcWebsite = new BbcWebsite("chrome");

            // go to the BBC home page
            BbcWebsite.bbcHomePage.VisitHomePage();

            // click sign in link
            BbcWebsite.bbcHomePage.ClickSignInLink();

            // enter a username
            BbcWebsite.bbcLoginPage.InputUserName(user);

            // enter a password
            BbcWebsite.bbcLoginPage.InputPassword("12345678l");

            // click the signin button
            BbcWebsite.bbcLoginPage.ClickSubmit();

            // check the error is correct
            Assert.That(BbcWebsite.bbcLoginPage.GetUserNameErrorText(), Is.EqualTo(expMsg));

        }

        [TearDown]
        public void CleanUp()
        {
            BbcWebsite.seleniumDriver.Quit();
        }
    }
}
