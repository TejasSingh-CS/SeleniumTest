using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Window.Maximize();
            IWebElement googleSearchBox = driver.FindElement(By.Name("q"));
            googleSearchBox.SendKeys("Amazon");
            googleSearchBox.SendKeys(Keys.Enter);
        }
    }
}
