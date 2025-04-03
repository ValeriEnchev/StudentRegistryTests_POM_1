using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver) 
        { 
        }
        public override string PageUrl => "https://e17ae9dd-ec22-4ff6-b5ea-638dd6021fd9-00-36pwunf5blcvd.riker.replit.dev/students";
        public ReadOnlyCollection<IWebElement> ListItemsStudents =>
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetStudentsList()
        {
            string[] elementsStudents = ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
    }
}
