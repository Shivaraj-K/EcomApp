using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp
{
    public  class Extent
    {
        public static ExtentReports e;
        public static ExtentHtmlReporter eh;
        public static ExtentTest et;
        public static ExtentTest T;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String path = dir.Replace("bin\\Debug\\net6.0\\", "TestResults\\Extendd.html");
        public static void ExtentMethod()
        {

            eh = new ExtentHtmlReporter(path);
            eh.Config.DocumentTitle = "Extent Report";
            eh.Config.ReportName = "Ecom Report";

            e = new ExtentReports();
            e.AttachReporter(eh);
            e.AddSystemInfo("Tester", "Shivaraj Guttedar");

        }

        public static void ExtentTearDown()
        {
            e.Flush();
        }


        public static String ScreenShot(IWebDriver d, ScenarioContext s)
        {
            ITakesScreenshot screenshot
                = (ITakesScreenshot)d;
            Screenshot ss = screenshot.GetScreenshot();

            String path = Path.Combine("C:\\Users\\SHIVARAJ GUTTEDAR\\source\\repos\\EcomerceTesting\\TestResults\\", s.ScenarioInfo.Title + ".png");
            ss.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}

