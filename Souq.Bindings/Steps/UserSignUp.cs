#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Souq.Pages;
using TechTalk.SpecFlow;

#endregion

namespace Souq.Bindings.Steps
{
    [Binding]
    internal class UserSignUp
    {
        private IWebDriver _driver;
        private HomePage HomePageObject;
        private LoginPage LoginPageObject;
        private SignupPage SignupPageObeject;

        [Given(@"the new user in the home page")]
        public void GivenTheNewUserInTheHomePage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            HomePageObject = new HomePage(_driver);
            LoginPageObject = new LoginPage(_driver);
            SignupPageObeject = new SignupPage(_driver);


            HomePageObject.OpenLoginPage();
        }

        [When(@"I click on signup link")]
        public void WhenIClickOnSignupLink()
        {
            LoginPageObject.SignupButton.Click();
            Assert.IsTrue(_driver.Url.Contains("eg-en/register.php"));
        }


        [When(@"user enter registration data ""(.*)"" , ""(.*)"" , ""(.*)"" , ""(.*)"" , ""(.*)"" , ""(.*)""")]
        public void WhenUserEnterRegistrationData(string firstname, string lastname, string email, string password,
            string country, string gender)
        {
            SignupPageObeject.UserRegistration(firstname, lastname, email, password, gender, country);
        }

        [Then(@"My ""(.*)"" should be beside the cart icon")]
        public void ThenMyShouldBeBesideTheCartIcon(string p0)
        {
            Assert.IsTrue(HomePageObject.LoginLink.Text.Contains(p0));
        }
    }
}