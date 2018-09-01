#region

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

#endregion

namespace Souq.Bindings.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        private IWebDriver _driver;


        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            _driver.Manage().Window.Maximize();

            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 120);
            _driver.Navigate().GoToUrl("https://egypt.souq.com/eg-en/");
            ScenarioContext.Current.Add("currentDriver", _driver);
        }


        [AfterScenario]
        public void RunAfterScenario()
        {
            _driver?.Quit();
        }
    }
}