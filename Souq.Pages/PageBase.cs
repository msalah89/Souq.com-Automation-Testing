#region

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

#endregion

namespace Souq.Pages
{
    public class PageBase
    {
        protected IWebDriver Driver;
        protected WebDriverWait DriverWait;

        //  create constructor 
        public PageBase(IWebDriver driver)
        {
            Driver = driver;
            DriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 60));
        }

        public IJavaScriptExecutor Jse { get; set; }

        public SelectElement Select { get; set; }

        public Actions Action { get; set; }

        protected static void ClickButton(IWebElement button)
        {
            button.Click();
        }

        protected static void SetTextElementText(IWebElement textElement, string value)
        {
            textElement.SendKeys(value);
        }

        public void ScrollToBottom()
        {
            Jse.ExecuteScript("scrollBy(0,2500)");
        }

        public void HoverAndClick(IWebElement elementToClick)
        {
            var action = new Actions(Driver);
            action.Click(elementToClick).Build().Perform();
        }

        public void ClearText(IWebElement element)
        {
            element.Clear();
        }
    }
}