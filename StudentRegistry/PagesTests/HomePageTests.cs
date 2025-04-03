using StudentRegistry.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.PagesTests
{
    public class TestHomePage : BaseTest
    {
        [Test]
        public void Test_HomePage_Content()
        {
            HomePage page = new HomePage(driver);
            page.Open();

            Assert.Multiple(() =>
            {
                Assert.That(page.GetPageTitle(), 
                    Is.EqualTo("MVC Example"));
                Assert.That(page.GetPageHeadingText(), 
                    Is.EqualTo("Students Registry"));
            });
            page.GetStudentsCount();
            Assert.Pass();
        }

        [Test]
        public void Test_HomePage_Links()
        {
            HomePage homePage = new HomePage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.That(new HomePage(driver).IsOpen());

            homePage.Open();
            homePage.LinkAddStudentPage.Click();
            Assert.That(new AddStudentPage(driver).IsOpen());

            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.That(new ViewStudentsPage(driver).IsOpen());

        }
    }
}
