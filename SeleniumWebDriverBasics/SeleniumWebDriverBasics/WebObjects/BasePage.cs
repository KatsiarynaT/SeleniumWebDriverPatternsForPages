using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumWebDriverBasics.WebObjects
{
    public class BasePage
    {
        protected By titleLocator;
        protected string title;

        protected BasePage(By TitleLocator, string Title)
        {
            titleLocator = TitleLocator;
            title = Title;
        }
    }
}
