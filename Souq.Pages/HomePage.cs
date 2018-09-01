#region

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

#endregion

namespace Souq.Pages
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            Jse = (IJavaScriptExecutor) driver;
            Action = new Actions(driver);
        }

        [FindsBy(How = How.Id, Using = "userNameField_topbar")]
        public IWebElement LoginLink { get; set; }


        [FindsBy(How = How.PartialLinkText, Using = "All Categories")]
        public IWebElement AllCategoriesLink { get; set; }


        public void OpenLoginPage()
        {
            var txt = LoginLink.Text;
            DriverWait.Until(ExpectedConditions.TextToBePresentInElement(LoginLink, "Log"));
            LoginLink.Click();
        }
    }
}