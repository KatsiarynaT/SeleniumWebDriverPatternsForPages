using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriverBasics.WebObjects;
using static System.Net.WebRequestMethods;

namespace SeleniumWebDriverBasics.Tests
{
    [TestFixture]
    public class YandexUnitTests : BaseTest
    {
        private readonly LoginPage loginPage = new LoginPage();
        private readonly EmailPage emailPage = new EmailPage();

        [Test]
        public void GetLoggedInToYandex()
        {
            //Act
            var actualAccountName = emailPage.GetActualUserName();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedAccountName, actualAccountName);
        }

        [Test]
        public void CreateDraftEmail()
        {
            //Act
            emailPage.CreateDraftEmail("Test Selenium", "Test Selenium from Kate");

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void GetSubjectAddresseeBodyFromDraftEmail()
        {
            //Act
            emailPage.CreateDraftEmail("Test Selenium", "Test Selenium from Kate");

            var actualAdressee = emailPage.GetActualAddressee();
            var actualSubject = emailPage.GetActualSubject();
            var actualMessageBody = emailPage.GetActualMessageBody();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
            Assert.AreEqual(ExpectedResults.expectedAdressee, actualAdressee);
            Assert.AreEqual(ExpectedResults.expectedMessageBody, actualMessageBody);
        }

        [Test]
        public void SendDraftEmail()
        {
            //Act
            emailPage.CreateDraftEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.GoToDraftEmails();
            emailPage.SendDraftEmail();

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void SendNewEmail()
        {
            //Act
            emailPage.CreateAndSendEmail("Test Selenium", "Test Selenium from Kate");

            var actualSubject = emailPage.GetActualSubject();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedSubject, actualSubject);
        }

        [Test]
        public void SentEmailIsNotPresentInDraftFolder()
        {
            //Act
            emailPage.CreateAndSendEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.GoToDraftEmails();

            var actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [Test]
        public void SentEmailIsNotPresentInTrashFolder()
        {
            //Act
            emailPage.CreateAndSendEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.GoToTrashEmails();

            var actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [Test]
        public void DeletedEmailIsNotPresentInDrafts()
        {
            //Act
            emailPage.CreateDraftEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.GoToDraftEmails();
            emailPage.DeleteAllEmails();

            var actualDraftInfoMessage = emailPage.GetActualDraftInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedDraftInfoMessage, actualDraftInfoMessage);
        }

        [Test]
        public void DeletedEmailIsNotPresentInTrash()
        {
            //Act
            emailPage.CreateDraftEmail("Test Selenium", "Test Selenium from Kate");
            emailPage.GoToDraftEmails();
            emailPage.DeleteAllEmails();
            emailPage.GoToTrashEmails();
            emailPage.DeleteAllEmails();

            var actualTrashInfoMessage = emailPage.GetActualTrashInfoMessage();

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTrashInfoMessage, actualTrashInfoMessage);
        }

        [Test]
        public void GetLoggedOutFromYandex()
        {
            //Act
            emailPage.GoToSignOutForm();

            var actualTitleAfterLogout = loginPage.GetActualLoginMessage(); ;

            //Assert
            Assert.AreEqual(ExpectedResults.expectedTitleAfterLogout, actualTitleAfterLogout);
        }
    }
}
