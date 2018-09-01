#region

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

#endregion

namespace Souq.Pages
{
    public class ForgetPasswordPage : PageBase
    {
        public ForgetPasswordPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='forgotPassword']/div[2]/input")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "password")]

        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "password_confirm")]

        public IWebElement PasswordConfirmTextBox { get; set; }


        [FindsBy(How = How.Id, Using = "flash-sess")]

        public IWebElement FlashAlert { get; set; }


        public void SendRecoverEmail(string email)
        {
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            DriverWait.Until(ExpectedConditions.TextToBePresentInElement(FlashAlert,
                "An email was sent to you to reset your password."));

            Thread.Sleep(10000);
        }

        public void EnterNewPassword(string password)
        {
            PasswordTextBox.SendKeys(password);
            PasswordConfirmTextBox.SendKeys(password);
            PasswordConfirmTextBox.SendKeys(Keys.Enter);
        }
    }
}