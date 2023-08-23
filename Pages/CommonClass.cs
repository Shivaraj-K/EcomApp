using BoDi;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp.Pages
{
    public interface ICommon
    {
        LoginPage login { get; }
    }
    public class CommonClass : ICommon
    {
        IWebDriver d;
        WebDriverWait ww;
        public CommonClass(IWebDriver drivers) 
        {
            this .d=drivers;
            ww = new WebDriverWait(d, TimeSpan.FromSeconds(50));
            login = new LoginPage(d);
        }

        public void waitForElements(By locator)
        {
            //WebDriverWait ww=new WebDriverWait(d,Duration.ofSeconds(50));
            ww.Until(ExpectedConditions.ElementIsVisible(locator));

        }
        public void waitForElement(By w)
        {
            ww.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(w));
        }
        public void waitForElements1(By y)
        {
            //WebDriverWait ww=new WebDriverWait(d,Duration.ofSeconds(50));
            ww.Until(ExpectedConditions.InvisibilityOfElementLocated(y));
        }

        public void script()
        {
            IJavaScriptExecutor j = (IJavaScriptExecutor)d;
            j.ExecuteScript("window.scrollBy(0,1000)");
        }

        public LoginPage login { get; }
    }
}
