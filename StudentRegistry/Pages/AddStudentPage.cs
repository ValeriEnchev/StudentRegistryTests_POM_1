using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl => "https://cda0c1fe-01f6-476c-b012-867896971e41-00-gxq8cviiys10.janeway.replit.dev/add-student";

        public IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));

        public IWebElement FieldStudentName => driver.FindElement(By.Name("name"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.Name("email"));
        public IWebElement ButtonAdd => driver.FindElement(By.CssSelector("button[type=submit]")); 

        public void AddStudent(string name, string email)
        {
            FieldStudentName.SendKeys(name);
            FieldStudentEmail.SendKeys(email);
            ButtonAdd.Click();
        }
        public string GetErrorMsg()
        {
            return ElementErrorMsg.Text;
        }

    }
}
