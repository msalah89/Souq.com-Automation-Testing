#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Souq.Bindings.Hooks;
using Souq.Pages;
using TechTalk.SpecFlow;

#endregion

namespace Souq.Bindings.Steps
{
    [Binding]
    internal class UserForgetPasswordSteps
    {
        private IWebDriver _driver;
        private ForgetPasswordPage ForgetPasswordPageObject;
        private HomePage HomePageObject;
        private LoginPage LoginPageObject;

        [Given(@"the user in the home page")]
        [Given(@"the user at the home page")]
        public void GivenTheUserAtTheHomePage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            HomePageObject = new HomePage(_driver);
            LoginPageObject = new LoginPage(_driver);
            ForgetPasswordPageObject = new ForgetPasswordPage(_driver);


            HomePageObject.OpenLoginPage();
        }


        [When(@"I click on forgetpassword Page")]
        public void WhenIClickOnForgetpasswordPage()
        {
            LoginPageObject.ForgetPasswordLink.Click();
            Assert.IsTrue(_driver.Url.Contains("eg-en/forgot_password.php"));
        }

        [When(@"I entered ""(.*)""")]
        public void WhenIEntered(string p0)
        {
            ForgetPasswordPageObject.SendRecoverEmail(p0);
            ScenarioContext.Current.Add("email", p0);
        }

        [Then(@"Check for password recovery email with ""(.*)"" and ""(.*)""")]
        public void ThenCheckForPasswordRecoveryEmailWithAnd(string p0, string p1)
        {
            var gmail = new GmailReader();
            var resetlink = gmail.GetResetPasswordLink();
            _driver.Navigate().GoToUrl(resetlink);
        }

        [Then(@"Enter new password ""(.*)""")]
        public void ThenEnterNewPassword(string p0)
        {
            ForgetPasswordPageObject.EnterNewPassword(p0);
        }

        [Then(@"""(.*)"" should appear at top right")]
        public void ThenShouldAppearAtTopRight(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}