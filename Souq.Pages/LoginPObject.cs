#region

using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

#endregion

namespace Souq.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            HomePage = new HomePage(driver);
        }

        private HomePage HomePage { get; }

        [FindsBy(How = How.Id, Using = "email")]

        public IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "password")]

        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "siteLogin")]

        public IWebElement LoginButton { get; set; }


        // Facebook Login Page UI Elements

        [FindsBy(How = How.Id, Using = "facebook_login")]
        public IWebElement FacebookButton { get; set; }


        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement FacebookEmailTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "pass")]
        public IWebElement FacebookPasswordTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement FacebookLoginButton { get; set; }


        //  Amazon Login Page UI Element


        [FindsBy(How = How.Id, Using = "LoginWithAmazon")]
        public IWebElement AmazonButton { get; set; }


        [FindsBy(How = How.Id, Using = "ap_email")]
        public IWebElement AmazonEmailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "ap_password")]
        public IWebElement AmazonPasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        public IWebElement AmazonLoginButton { get; set; }


        // SignUp Button 
        [FindsBy(How = How.LinkText, Using = "Sign Up")]
        public IWebElement SignupButton { get; set; }


        // Forget Password Link 
        [FindsBy(How = How.LinkText, Using = "Forgot Password?")]
        public IWebElement ForgetPasswordLink { get; set; }


        /// <summary>
        ///     Login in Souq.com using email and password
        /// </summary>
        /// <param name="email"> Souq.com user email address</param>
        /// <param name="password">Souq.com user password</param>
        public void LoginWithEmail(string email, string password)
        {
            EmailTextBox.SendKeys(email);
            PasswordTextBox.SendKeys(password);
            LoginButton.Click();
        }


        /// <summary>
        ///     Login in Souq.com using Facebook Account
        /// </summary>
        /// <param name="email"> Facebook email address or telephone number</param>
        /// <param name="password">Facebook password</param>
        public void LoginUsingFacebook(string email, string password)
        {
            FacebookButton.Click();
            DriverWait.Until(ExpectedConditions.UrlContains("facebook.com"));
            FacebookEmailTextBox.SendKeys(email);
            FacebookPasswordTextBox.SendKeys(password);
            FacebookLoginButton.Click();
        }

        /// <summary>
        ///     Login in Souq.com using Amazon Account
        /// </summary>
        /// <param name="email"> Amazin email address </param>
        /// <param name="password">Amazon password</param>
        public void LoginUsingAmazon(string email, string password)
        {
            // Switching to amazon login popup window
            AmazonButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().Last());
            DriverWait.Until(ExpectedConditions.UrlContains("amazon.com"));

            // Entering Amazon User Credentials
            AmazonEmailTextBox.SendKeys(email);
            AmazonPasswordTextBox.SendKeys(password);
            AmazonLoginButton.Click();

            // returning back to Souq.com Login Page 
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().First());
        }
    }
}