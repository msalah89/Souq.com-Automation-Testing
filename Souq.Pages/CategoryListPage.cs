#region

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

#endregion

namespace Souq.Pages
{
    public class CategoryListPage : PageBase
    {
        public CategoryListPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public void OpenCategory(string category)
        {
            Driver.FindElement(By.PartialLinkText(category)).Click();
        }
    }
}