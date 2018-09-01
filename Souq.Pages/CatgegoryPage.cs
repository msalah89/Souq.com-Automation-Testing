#region

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

#endregion

namespace Souq.Pages
{
    public class CategoryPage : PageBase
    {
        public CategoryPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public void OpenItem(string item)
        {
            Driver.FindElement(By.PartialLinkText(item)).Click();
        }
    }
}