using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp.Pages
{
    public class PlaceOrder :CommonClass
    {

        IWebDriver d;
        public PlaceOrder(IWebDriver d) :base(d)
        {
            this.d = d;
            PageFactory.InitElements(d, this);
        }

        [FindsBy(How=How.XPath,Using = "//section/button")]
        private IList<IWebElement> country { get; set; }

        [FindsBy(How=How.XPath,Using = "//input[@placeholder='Select Country']")]
        private IWebElement search { get; set; }

        private By submit = By.LinkText("PLACE ORDER");

        [FindsBy(How = How.LinkText, Using = "PLACE ORDER")]
        private IWebElement sub { get; set; }

        public void SearchCountry(String c_Name)
        {
            search.Clear();
            search.SendKeys(c_Name);
            for(int i=0; i<country.Count; i++)
            {
                if (country[i].Text.Equals("India"))
                {
                    country[i].Click();
                    break;
                }
            }
        }

        public Orders placeTheOrder()
        {
            waitForElements(submit);
            sub.Click();

            return new Orders(d);

        }

    }
}
