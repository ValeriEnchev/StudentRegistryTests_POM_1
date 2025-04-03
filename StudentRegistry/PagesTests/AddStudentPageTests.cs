using StudentRegistry.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.PagesTests
{
    public class AddStudentPageTests : BaseTest
    {
        [Test]
        public void Test_AddStudentPage_Content()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(addStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
                Assert.That(addStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));

                Assert.That(addStudentPage.FieldStudentName.Text, Is.Empty);
                Assert.That(addStudentPage.FieldStudentEmail.Text, Is.Empty);
                Assert.That(addStudentPage.ButtonAdd.Text, Is.EqualTo("Add"));
            });
        }

        [Test]
        public void Test_AddStudentPage_Links()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);

            addStudentPage.Open();
            addStudentPage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkAddStudentPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen());
        }

        [Test]
        public void Test_AddStudentPage_AddValidStudent()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            string name = "New student" + DateTime.Now.Ticks;
            string email = "email" + DateTime.Now.Ticks + "@email.com";
            string expected = $"{name} ({email})";
            //Console.WriteLine(expected);
            addStudentPage.AddStudent(name, email);
            ViewStudentsPage viewStudentsPage = new ViewStudentsPage(driver);
            Assert.That(viewStudentsPage.IsOpen());
            string[] students = viewStudentsPage.GetStudentsList();
            //Assert.That(students[students.Length - 1], Is.EqualTo(expected));
            Assert.That(students, Does.Contain(expected));
        }

        [Test]
        public void Test_AddStudentPage_AddInvalidStudent()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.Open();

            string name = string.Empty;
            string email = "email" + DateTime.Now.Ticks + "@email.com";
            addStudentPage.AddStudent(name, email);

            Assert.That(addStudentPage.IsOpen());
            Assert.That(addStudentPage.ElementErrorMsg.Displayed);
            Assert.That(addStudentPage.ElementErrorMsg.Text, 
                Does.Contain("Cannot add student."));
            Assert.That(addStudentPage.GetErrorMsg(), 
                Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }


    }
}
