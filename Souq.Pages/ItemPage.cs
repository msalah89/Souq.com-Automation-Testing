#region

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

#endregion

namespace Souq.Pages
{
    public class ItemPage : PageBase
    {
        public ItemPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "product-title")]
        public IWebElement ProductTitle { get; set; }


        [FindsBy(How = How.ClassName, Using = "item-details-mini")]
        public IWebElement Description { get; set; }


        public bool CheckItemNameandCategory(string item, string category)
        {
            if (ProductTitle.Text.Contains(item) && ProductTitle.Text.Contains(category)) return true;
            return false;
        }

        public void OpenItem(string item)
        {
            Driver.FindElement(By.PartialLinkText(item)).Click();
        }
    }
}