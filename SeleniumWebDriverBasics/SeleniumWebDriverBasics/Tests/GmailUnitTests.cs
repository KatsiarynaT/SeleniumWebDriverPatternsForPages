using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace SeleniumWebDriverBasics.Tests
{
    [TestFixture]
    public class GmailUnitTests
    {
        private IWebDriver driver;
        private string baseUrl;

        [SetUp]
        public void TestSetup()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            driver = new FirefoxDriver(service);
            baseUrl = "https://www.google.com/en";
            driver.Navigate().GoToUrl(baseUrl);

            //Create gmail account:
            //this.baseUrl = "https://www.google.com/intl/en/gmail/about/";
            //this.driver.Navigate().GoToUrl(this.baseUrl);

            //this.driver.FindElement(By.XPath("//span[text()='Create an account']")).Click();

            //this.driver.FindElement(By.ClassName("TquXA")).Click();
            //this.driver.FindElement(By.XPath("//span[text()='English (United States)']")).Click();

            //this.driver.FindElement(By.Name("firstName")).SendKeys("Kate");
            //this.driver.FindElement(By.Name("lastName")).SendKeys("Selenium");
            //this.driver.FindElement(By.Id("username")).SendKeys("KateTest15796");
            //this.driver.FindElement(By.Name("Passwd")).SendKeys("SeleniumTest-01");
            //this.driver.FindElement(By.Name("ConfirmPasswd")).SendKeys("SeleniumTest-01");
            //this.driver.FindElement(By.XPath("//span[text()='Next']")).Click();

            //this.driver.FindElement(By.Id("phoneNumberId")).SendKeys("551583944");
            //this.driver.FindElement(By.Id("month")).Click();
            //this.driver.FindElement(By.XPath("//select/option[text()='July']")).Click();
            //this.driver.FindElement(By.Id("day")).SendKeys("1");
            //this.driver.FindElement(By.Id("year")).SendKeys("1999");
            //this.driver.FindElement(By.Id("gender")).Click();
            //this.driver.FindElement(By.XPath("//select/option[text()='Female']")).Click();
            //this.driver.FindElement(By.XPath("//span[text()='Next']")).Click();

            //this.driver.FindElement(By.XPath("//span[text()='I agree']")).Click();
        }

        [Test]
        public void LoginToGmail()
        {
            //Arrange
            var expectedAccountName = "Kate Test";

            //Act
            driver.FindElement(By.XPath("//a[text()='Sign in']")).Click();
            driver.FindElement(By.Id("identifierId")).SendKeys("testkate837@gmail.com");
            driver.FindElement(By.XPath("//span[text()='Next']")).Click();
            IsElementVisible(By.XPath("//input[@aria-label='Enter your password']"));
            driver.FindElement(By.XPath("//input[@aria-label='Enter your password']")).SendKeys("cKbEt9qR2h2AH4f");
            driver.FindElement(By.XPath("//span[text()='Next']")).Click();
            IsElementVisible(By.XPath("//a[contains (@aria-label,'Google Account')]"));

            driver.FindElement(By.XPath("//a[contains (@aria-label,'Google Account')]")).Click();

            driver.SwitchTo().Frame(driver.FindElement(By.Name("account")));
            var actualAccountName = driver.FindElement(By.XPath("//div[text()='Kate Test']")).Text;

            //Assert
            Assert.AreEqual(expectedAccountName, actualAccountName);
        }

        [Test]
        public void CreateDraftEmail()
        {
            //Arrange
            var expectedSubject = "TestEmail";

            //Act
            driver.FindElement(By.XPath("//a[text()='Sign in']")).Click();
            driver.FindElement(By.Id("identifierId")).SendKeys("testkate837@gmail.com");
            driver.FindElement(By.XPath("//span[text()='Next']")).Click();
            IsElementVisible(By.XPath("//input[@aria-label='Enter your password']"));
            driver.FindElement(By.XPath("//input[@aria-label='Enter your password']")).SendKeys("cKbEt9qR2h2AH4f");
            driver.FindElement(By.XPath("//span[text()='Next']")).Click();
            IsElementVisible(By.XPath("//a[text()='Gmail']"));

            driver.FindElement(By.XPath("//a[text()='Gmail']")).Click();
            IsElementVisible(By.XPath("//div[@class='T-I T-I-KE L3']"));
            driver.FindElement(By.XPath("//div[@class='T-I T-I-KE L3']")).Click();
            IsElementVisible(By.XPath("//span[text()='To']"));
            //this.driver.FindElement(By.XPath("//span[text()='To']")).Click();

            //this.driver.SwitchTo().Frame(this.driver.FindElement(By.Id("r34a5m1e9juu")));
            //this.driver.FindElement(By.XPath("//div[text()='Kate']")).Click();
            //this.driver.FindElement(By.XPath("//span[text()='Insert']")).Click();

            //this.driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//input[@aria-label='Subject']")).SendKeys("TestEmail");
            driver.FindElement(By.XPath("//div[@aria-label='Message Body']")).SendKeys("Test Email");
            driver.FindElement(By.XPath("//a[contains (@aria-label,'Drafts')]")).Click();

            var actualSubject = driver.FindElement(By.XPath("//span[text()='TestEmail2']")).Text;

            //Assert
            Assert.AreEqual(expectedSubject, actualSubject);
        }

        public void IsElementVisible(By element, int timeoutSecs = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSecs)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        [TearDown]
        public void TestTearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
