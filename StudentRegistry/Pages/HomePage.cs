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
        public override string PageUrl => "https://e17ae9dd-ec22-4ff6-b5ea-638dd6021fd9-00-36pwunf5blcvd.riker.replit.dev/";
        public IWebElement ElementStudentsCount =>
            driver.FindElement(By.CssSelector("body > p > b"));
        public string GetStudentsCount()
        {
            return ElementStudentsCount.Text;
        }
    }
}
