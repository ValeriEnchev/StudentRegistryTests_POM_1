﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.Pages
{
    public class BasePage
    {
        public readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public virtual string PageUrl { get; }
        public IWebElement LinkHomePage =>
            driver.FindElement(By.LinkText("Home"));
        public IWebElement LinkViewStudentsPage =>
            driver.FindElement(By.LinkText("View Students"));
        public IWebElement LinkAddStudentPage =>
            driver.FindElement(By.LinkText("Add Student"));
        public IWebElement ElementPageHeading =>
            driver.FindElement(By.CssSelector("body > h1"));
        public void Open()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
        public bool IsOpen()
        {
            return driver.Url == PageUrl;
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }
        public string GetPageHeadingText()
        {
            return ElementPageHeading.Text;
        }
    }
}
