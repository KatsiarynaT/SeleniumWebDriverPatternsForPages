using OpenQA.Selenium;
using SeleniumWebDriverBasics.WebObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverBasics.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected string composeLinkText = "Compose";
        protected string login = "katetest.selenium@yandex.com";
        protected string password = "testSelenium001";

        [SetUp]
        public void TestSetup()
        {
            this.driver = Browser.GetDriver();
            this.baseUrl = HomePage.url;

            Browser.NavigateTo(this.baseUrl);
            Browser.MaximizeWindow();

            var homePage = new HomePage();
            homePage.ClickOnLoginButton();
            new LoginPage().Login(login, password);
            homePage.WaitForComposeLinkIsVisible();
        }

        [TearDown]
        public void CleanUp()
        {
            Browser.driver.Close();
            Browser.driver.Quit();
            Browser.Quit();
        }
    }
}
