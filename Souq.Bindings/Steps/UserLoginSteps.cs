#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Souq.Pages;
using TechTalk.SpecFlow;

#endregion

namespace Souq.Bindings.Steps
{
    [Binding]
    public class UserLoginSteps
    {
        private IWebDriver _driver;
        private HomePage HomePageObject { get; set; }
        private LoginPage LoginPageObject { get; set; }

        [Given(@"the user in the souq home page")]
        public void GivenTheUserInTheSouqHomePage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            HomePageObject = new HomePage(_driver);
            HomePageObject.OpenLoginPage();
        }

        [When(@"I click on Login link")]
        public void WhenIClickOnLoginLink()
        {
            Assert.IsTrue(_driver.Url.Contains("eg-en/login.php"));
        }


        [When(@"I entered  ""(.*)"" , ""(.*)"" in login ""(.*)""")]
        public void WhenIEnteredInLogin(string p0, string p1, string p2)
        {
            LoginPageObject = new LoginPage(_driver);

            switch (p2)
            {
                case "emailandpassword":
                    LoginPageObject.LoginWithEmail(p0, p1);
                    break;
                case "facebook":
                    LoginPageObject.LoginUsingFacebook(p0, p1);
                    break;
                case "amazon":
                    LoginPageObject.LoginUsingAmazon(p0, p1);
                    break;
            }
        }

        [Then(@"My ""(.*)"" should appear beside the cart")]
        public void ThenMyShouldAppearBesideTheCart(string p0)
        {
            Assert.IsTrue(HomePageObject.LoginLink.Text.Contains(p0));
        }
    }
}