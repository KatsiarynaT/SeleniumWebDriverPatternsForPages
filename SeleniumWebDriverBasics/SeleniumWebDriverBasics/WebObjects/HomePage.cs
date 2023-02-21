using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverBasics.WebObjects
{
    public class HomePage : BasePage
    {
        public static readonly String url = "https://yandex.com";
        private static readonly By mailLinkXpath = By.XPath("(//a[@href='https://mail.yandex.com/']/a)[2]");
        public HomePage() : base(mailLinkXpath, "Home Page") { }
        private static readonly BaseElement loginButton = new BaseElement(By.XPath("//div[text()='Log in']"));
        private static readonly BaseElement composeLink = new BaseElement(By.XPath("//a[contains(@href,'/compose')]"));

        public void ClickOnLoginButton()
        {
            loginButton.Click();
        }

        public void WaitForComposeLinkIsVisible()
        {
            composeLink.WaitForIsVisible();
        }

        public string GetTextFromComposeLink() => composeLink.GetText();

        public void ClickOnComposeLink()
        {
            composeLink.Click();
        }
    }
}
