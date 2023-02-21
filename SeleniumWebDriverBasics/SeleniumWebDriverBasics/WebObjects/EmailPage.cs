using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverBasics.WebObjects
{
    public class EmailPage : BasePage
    {

        private static readonly By loggedInUser = By.ClassName("user-account__name");

        public EmailPage() : base(loggedInUser, "Email Page") { }

        private static readonly BaseElement createEmailButton = new BaseElement(By.XPath("//a[@class='mail-ComposeButton js-main-action-compose']"));
        private static readonly BaseElement recepientField = new BaseElement(By.ClassName("composeYabbles"));
        private static readonly BaseElement recepientOption = new BaseElement(By.ClassName("ContactsSuggestItemDesktop-Email"));
        private static readonly BaseElement subjectField = new BaseElement(By.XPath("//input[@class='composeTextField ComposeSubject-TextField']"));
        private static readonly BaseElement bodyField = new BaseElement(By.XPath("//div[contains(@class, 'cke_enable_context_menu')]"));
        private static readonly BaseElement draftsOption = new BaseElement(By.XPath("//a[@data-title='Drafts']"));
        private static readonly BaseElement draftEmail = new BaseElement(By.XPath("//span[@class='mail-MessageSnippet-FromText']"));
        private static readonly BaseElement sendButton = new BaseElement(By.XPath("(//button[contains(@class, 'ComposeControlPanelButton-Button')])[1]"));
        private static readonly BaseElement popupWindow = new BaseElement(By.XPath("//a[@class='control link link_theme_normal ComposeDoneScreen-Link']"));
        private static readonly BaseElement userLogo = new BaseElement(By.XPath("(//div/img[@class='user-pic__image'])[1]"));
        private static readonly BaseElement logOutOption = new BaseElement(By.XPath("//span[text()='Log out']"));
        private static readonly BaseElement deleteButton = new BaseElement(By.XPath("//span[text()='Delete']"));
        private static readonly BaseElement deletedOption = new BaseElement(By.XPath("//a[@data-title='Deleted']"));
        private static readonly BaseElement allEmailsCheckbox = new BaseElement(By.XPath("(//span[@class='checkbox_view'])[1]"));
        private static readonly BaseElement actualUserName = new BaseElement(By.XPath("//a[contains(@class, 'user-account_left-name')]/span[1]"));
        private static readonly BaseElement actualAdressee = new BaseElement(By.XPath("(//span[contains(@class, 'mail-MessageSnippet-Item_sender')]/span)[1]"));
        private static readonly BaseElement actualSubject = new BaseElement(By.XPath("(//span[contains(@class, 'mail-MessageSnippet-Item_subject')]/span)[1]"));
        private static readonly BaseElement actualMessageBody = new BaseElement(By.XPath("(//span[contains(@class, 'mail-MessageSnippet-Item_firstline')]/span)[1]"));
        private static readonly BaseElement actualDraftInfoMessage = new BaseElement(By.XPath("//span[text()='No messages in Drafts']"));
        private static readonly BaseElement actualTrashInfoMessage = new BaseElement(By.XPath("//span[text()='No messages in Trash']"));

        public void SwitchToEmailPage()
        {
            var currentTab = Browser.driver.WindowHandles.Last();
            Browser.driver.SwitchTo().Window(currentTab);
        }

        public void CreateDraftEmail(string subjectText, string bodyText)
        {
            createEmailButton.Click();
            recepientField.Click();
            recepientOption.Click();
            subjectField.SendKeys(subjectText);
            bodyField.SendKeys(bodyText);
            draftsOption.Click();
        }

        public void CreateAndSendEmail(string subjectText, string bodyText)
        {
            createEmailButton.Click();
            recepientField.Click();
            recepientOption.Click();
            subjectField.SendKeys(subjectText);
            bodyField.SendKeys(bodyText);
            sendButton.Click();
            popupWindow.Click();
        }

        public void SendDraftEmail()
        {
            draftEmail.Click();
            sendButton.Click();
            popupWindow.Click();
        }

        public void GoToDraftEmails()
        {
            draftsOption.Click();
        }

        public void GoToSignOutForm()
        {
            userLogo.Click();
            logOutOption.Click();
        }

        public void GoToTrashEmails()
        {
            deletedOption.Click();
        }

        public void DeleteAllEmails()
        {
            allEmailsCheckbox.Click();
            deleteButton.Click();
        }

        public string GetActualUserName() => actualUserName.GetText();

        public string GetActualAddressee() => actualAdressee.GetText();

        public string GetActualSubject() => actualSubject.GetText();

        public string GetActualMessageBody() => actualMessageBody.GetText();

        public string GetActualDraftInfoMessage() => actualDraftInfoMessage.GetText();

        public string GetActualTrashInfoMessage() => actualTrashInfoMessage.GetText();
    }
}