using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp.Pages
{
    public class Orders:CommonClass
    {

        IWebDriver d;
        public Orders(IWebDriver d):base(d) 
        {
            this.d = d;
            PageFactory.InitElements(d, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h1")]
        private IWebElement text;

        public String SuccessfulyOrdered()
        {
           return text.Text;
        }
    }
}
