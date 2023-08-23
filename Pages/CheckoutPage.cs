using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
//using PageFactoryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp.Pages
{
    public class CheckoutPage : CommonClass
    {
        IWebDriver d;
        public CheckoutPage(IWebDriver d) : base(d)
        {
            this.d = d;
            PageFactory.InitElements(d, this);
        }

        [FindsBy(How = How.XPath, Using = "(//button[@class='btn btn-primary'])[3]")]
        private IWebElement check { get; set; }

        private By checkEle = By.XPath("(//button[@class='btn btn-primary'])[3]");

        public PlaceOrder ClickToChecout()
        {
            script();
            waitForElements(checkEle);
            check.Click();
            return new PlaceOrder(d);

        }
    }
}
