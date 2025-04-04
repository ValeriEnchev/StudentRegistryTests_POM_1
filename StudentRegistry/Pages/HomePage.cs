using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) 
        { 
        }
        public override string PageUrl => "https://cda0c1fe-01f6-476c-b012-867896971e41-00-gxq8cviiys10.janeway.replit.dev/";
        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p > b"));
        public string GetStudentsCount()
        {
            return ElementStudentsCount.Text;
        }
    }
}
