#region

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

#endregion

namespace Souq.Pages
{
    public class SignupPage : PageBase
    {
        public SignupPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "gender")]

        public IList<IWebElement> GenderRadioButton { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]

        public IWebElement FirstNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]

        public IWebElement LastNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "email")]

        public IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "password")]

        public IWebElement PasswordTextBox { get; set; }


        [FindsBy(How = How.Id, Using = "select_country")]
        public IWebElement CountrySelectBox { get; set; }


        [FindsBy(How = How.Id, Using = "siteRegister")]

        public IWebElement SignupButton { get; set; }


        public void UserRegistration(string firstName, string lastName, string email, string password, string gender,
            string country)
        {
            email = email.Replace("_random", Guid.NewGuid().ToString());
            FirstNameTextBox.SendKeys(firstName);
            LastNameTextBox.SendKeys(lastName);
            EmailTextBox.SendKeys(email);
            PasswordTextBox.SendKeys(password);
            foreach (var genderBtn in GenderRadioButton)
            {
                var genderValue = genderBtn.GetAttribute("value");
                if (genderValue == gender)
                {
                    genderBtn.Click();
                    break;
                }
            }

            var countrySelect = new SelectElement(CountrySelectBox);
            countrySelect.SelectByText(country);


            DriverWait.Until(ExpectedConditions.ElementToBeClickable(SignupButton)).SendKeys(Keys.Enter);
        }
    }
}