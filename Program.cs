using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
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
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/List_of_large_language_models");
            driver.Manage().Window.Maximize();

            //Table xpath
            var table = driver.FindElement(By.XPath("//table[contains(@class, 'wikitable sortable')]"));

            //List to hold extracted data
            List<NameDto> nameList = new List<NameDto>();

            //Count rows
            int rowLength = driver.FindElements(By.XPath("//table[contains(@class, 'wikitable sortable')]/tbody/tr")).Count;
            Console.WriteLine("Number of rows in the table: " + rowLength);

            for(int i=1; i<=rowLength; i++)
            {
                IWebElement columnName = driver.FindElement(By.XPath("//table[contains(@class, 'wikitable sortable')]/tbody/tr[" + i + "]/td[1]"));
                Console.WriteLine("Name " + i + " is: " + columnName.Text);
                IWebElement columnRelease = driver.FindElement(By.XPath("//table[contains(@class, 'wikitable sortable')]/tbody/tr[" + i + "]/td[2]"));
                Console.WriteLine("Release Date " + i + " is: " + columnRelease.Text);

                //Store into DTO list
                NameDto nameDto = new NameDto();
                nameDto.Name = columnName.Text;
                nameDto.ReleaseDate = columnRelease.Text;

                nameList.Add(nameDto);

            }

            string jsonOutput = JsonConvert.SerializeObject(nameList, Formatting.Indented);
            Console.WriteLine(jsonOutput);

            driver.Quit();
        }
    }
}
