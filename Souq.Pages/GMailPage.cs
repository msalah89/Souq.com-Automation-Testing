#region

using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

#endregion

namespace Souq.Pages
{
    public class GMailPage : PageBase
    {
        public GMailPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "identifierId")]

        public IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "password")]

        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "bog")]

        public IList<IWebElement> EmailThreads { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='gb_bb gbii")]
        public IWebElement ProfileLogo { get; set; }

        public void GotoUrl()
        {
            var act = new Actions(Driver);
            act.KeyDown(Keys.Control).SendKeys("t").Perform();
            Driver.Navigate().GoToUrl("http://gmail.com");
        }

        public void Login(string username, string password)
        {
            DriverWait.Until(ExpectedConditions.ElementToBeClickable(EmailTextBox)).Click();

            EmailTextBox.SendKeys(Keys.Enter);
            EmailTextBox.SendKeys(username);
            EmailTextBox.SendKeys(Keys.Enter);

            DriverWait.Until(ExpectedConditions.ElementToBeClickable(PasswordTextBox)).SendKeys(password);
            PasswordTextBox.SendKeys(Keys.Enter);
            DriverWait.Until(ExpectedConditions.UrlContains("https://mail.google.com/mail/u/0/#inbox"));
            var emails = Driver.FindElements(By.ClassName("bog"));

            foreach (var email in emails)
                if (email.Text.Contains("Souq.com"))
                    email.Click();
            //  action.MoveToElement(email).Click().Perform();

            ClickEmail("Souq.com Password Reset");
        }

        public void ClickEmail(string emailSubject)
        {
            //  WaitForVisible(_drvier, ProfileLogo);
            var emailthreadss = Driver.FindElements(By.CssSelector("bog"));
            for (var i = 0; i < emailthreadss.Count(); i++)
                if (emailthreadss[i].Text.Contains(emailSubject))
                {
                    emailthreadss[i].Click();
                    break;
                }
        }
    }
}