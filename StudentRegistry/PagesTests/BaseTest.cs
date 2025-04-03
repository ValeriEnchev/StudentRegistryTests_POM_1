using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistry.PagesTests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            options.AddArguments("no-sandbox");
            options.AddArguments("disable-dev-shm-usage");
            options.AddArguments("disable-gpu");
            options.AddArguments("window-size=1920x1080");

            string userDataDir = Path.Combine(Path.GetTempPath(),
                Path.GetRandomFileName());
            Directory.CreateDirectory(userDataDir);
            options.AddArguments($"--user-data-dir={userDataDir}");

            driver = new ChromeDriver(options);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
        }
    }
}
