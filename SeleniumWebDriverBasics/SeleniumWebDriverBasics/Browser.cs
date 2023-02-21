using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumWebDriverBasics
{
    public class Browser
    {
        public static IWebDriver driver;
        private static Browser currentInstance;
        public static BrowserFactory.BrowserType currentBrowser;
        public static int ImplWait;
        public static double timeOutForElement;
        public static string browser;

        private Browser()
        {
            InitParamas();
            driver = BrowserFactory.GetDriver(currentBrowser, ImplWait);
        }

        public static void InitParamas() 
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            timeOutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            browser = Configuration.Browser;
            Enum.TryParse(browser, out currentBrowser );
        }

        public static Browser GetInstance() => currentInstance ?? (currentInstance = new Browser());

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }

        public static IWebDriver GetDriver() => driver;
        public static void Quit()
        {
            driver.Close();
            driver.Quit();
            driver = null;
            browser = null;
            currentInstance = null;
        }
    }
}
