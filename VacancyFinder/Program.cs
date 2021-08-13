using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;

namespace VacancyFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToWebDriverFolder = "WebDriver";
            
            using(IWebDriver driver = new OperaDriver(pathToWebDriverFolder) )
            {
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                driver.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");
                //Sleep();

                driver.Manage().Window.Maximize();
                //Sleep();

                IWebElement deptButtonElem = driver.FindElement(By.XPath("html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/button"));
                deptButtonElem.Click();

                IWebElement deptAhRef = driver.FindElement(By.XPath(@"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div/div/a[4]"));
                deptAhRef.Click();

                IWebElement languageButtonElem = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/button"));
                languageButtonElem.Click();

                //IWebElement languageDropDown = driver.FindElement(By.XPath(@"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div"));
                //var DropDown = new SelectElement(languageDropDown);
                
                var languageDropDown = driver.FindElements(By.XPath(@"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div"));

                foreach (var item in collection)
                {

                }

                
                //DropDown.SelectByText("Разработка продуктов");

                //SelectElement selectLanguage = new SelectElement(languageDropDown);
                //selectLanguage.SelectByText("Английский");

                //var element = driver.FindElement(By.XPath(@"//*[@id=""root""]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div"));
                //Actions action = new Actions(driver);
                //action.MoveToElement(element);
                //var DropDown = new SelectElement(element);
                //DropDown.SelectByText("Разработка продуктов");
                //*[@id="sl"]
                //element.Click();
                //*[@id="root"]/div/div[1]/div/div[2]/div[1]/div/div[2]/div/div

                //English
                //*[@id="root"]/div/div[1]/div/div[2]/div[1]/div/div[3]/div/div/div/div[2]/label
                Console.WriteLine();
                //Actions action = new Actions(driver);
                //action.MoveToElement(element);
                //var DropDown = new SelectElement(element);
                //DropDown.SelectByText("Разработка продуктов");

                // wait.Until(/*webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed*/);
                //IWebElement firstResult = driver.FindElement(By.CssSelector("h3"));
                //Console.WriteLine(firstResult.GetAttribute("textContent"));
            }
            
            Console.ReadKey();
        }

        private static void Sleep()
        {
            Thread.Sleep(5000);
        }

    }
}
