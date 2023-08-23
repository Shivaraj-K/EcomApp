using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace EcomerceApp.Pages
{
    public class Driver
    {
        IWebDriver d;


        public IWebDriver DriverInIt()
        {
            String URL = ConfigurationManager.AppSettings["url"];
            String browser = ConfigurationManager.AppSettings["browser"];
            //Console.WriteLine(URL);
            //string json = File.ReadAllText("C:\\Users\\SHIVARAJ GUTTEDAR\\source\\repos\\EcomerceTesting\\Properties.json");
            //dynamic config = JsonConvert.DeserializeObject(json);
            //// String url = config.url;
           // String browser = "";  /*config.browser*/

            Console.WriteLine(browser);

            if (d == null)
            {
                if (browser == "chrome")
                {
                    d = new ChromeDriver();
                }
                else if (browser == "firefox")
                {
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    FirefoxOptions f = new FirefoxOptions();
                    f.AddArgument("no-sandbox");
                    d = new FirefoxDriver();
                }

                else if (browser == "edge")
                {
                    d = new EdgeDriver();
                }
                // d =new FirefoxDriver();
                d.Url =" https://rahulshettyacademy.com/client";
                d.Manage().Window.Maximize();
                d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            }

            return d;
        }
    }
}
