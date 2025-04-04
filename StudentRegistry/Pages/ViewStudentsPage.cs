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
        
        public override string PageUrl => "https://cda0c1fe-01f6-476c-b012-867896971e41-00-gxq8cviiys10.janeway.replit.dev/students";
        public ReadOnlyCollection<IWebElement> ListItemsStudents =>
            driver.FindElements(By.CssSelector("body > ul > li"));

        public string[] GetStudentsList()
        {
            string[] elementsStudents = ListItemsStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
    }
}
