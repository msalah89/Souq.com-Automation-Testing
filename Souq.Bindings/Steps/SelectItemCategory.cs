#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Souq.Pages;
using TechTalk.SpecFlow;

#endregion

namespace Souq.Bindings.Steps
{
    [Binding]
    internal class SelectItemCategory
    {
        private IWebDriver _driver;
        private CategoryListPage CategoryListPageObject;
        private CategoryPage CategoryPageObject;
        private HomePage HomePageObject;
        private ItemPage ItemPageObject;

        [Given(@"the user is in the home page")]
        public void GivenTheUserIsInTheHomePage()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            HomePageObject = new HomePage(_driver);
        }

        [When(@"I click on All Categories")]
        public void WhenIClickOnAllCategories()
        {
            HomePageObject.AllCategoriesLink.Click();
        }

        [When(@"I choose ""(.*)"" name")]
        public void WhenIChooseName(string p0)
        {
            CategoryListPageObject = new CategoryListPage(_driver);
            CategoryListPageObject.OpenCategory(p0);
        }

        [When(@"select ""(.*)""")]
        public void WhenSelect(string p0)
        {
            CategoryPageObject = new CategoryPage(_driver);
            CategoryPageObject.OpenItem(p0);
        }

        [Then(@"I should be in ""(.*)"" page and ""(.*)"" should be mentioned")]
        public void ThenIShouldBeInPageAndShouldBeMentioned(string p0, string p1)
        {
            ItemPageObject = new ItemPage(_driver);
            Assert.IsTrue(ItemPageObject.CheckItemNameandCategory(p0, p1));
        }
    }
}