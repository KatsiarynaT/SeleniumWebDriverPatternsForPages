using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverBasics.WebObjects
{
    public class LoginPage : BasePage
    {
        public static readonly String url = "https://passport.yandex.com/auth/welcome";
        private static readonly By loginFieldXpath = (By.Id("passp-field-login"));
        public LoginPage() : base(loginFieldXpath, "Login Field") { }
        private static readonly BaseElement loginField = new BaseElement(loginFieldXpath);
        private static readonly BaseElement loginButton = new BaseElement(By.Id("passp:sign-in"));
        private static readonly BaseElement passwordField = new BaseElement(By.Id("passp-field-passwd"));
        private static readonly BaseElement ActualLoginMessage = new BaseElement(By.XPath("//div[@class='passp-auth-screen passp-welcome-page']/h1/span"));

        public void EnterLogin(string Login)
        {
            loginField.SendKeys(Login);
        }

        public void ClickConfirmationButton()
        {
            loginButton.Click();
        }

        public void EnterPassword(string Password)
        {
            passwordField.SendKeys(Password);
        }

        public void Login(string Login, string Password)
        {
            EnterLogin(Login);
            ClickConfirmationButton();
            EnterPassword(Password);
            ClickConfirmationButton();
        }

        public string GetActualLoginMessage() => ActualLoginMessage.GetText();
    }
}
