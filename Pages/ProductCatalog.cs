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
    public class ProductCatalog : CommonClass
    {
        IWebDriver d;
        

        public ProductCatalog(IWebDriver d) :base(d)
        {
            this.d = d;
            PageFactory.InitElements(d, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@routerlink='/dashboard/cart']")]
        private IWebElement cart { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".mb-3")]
        private IList<IWebElement> pros { get; set; }

       private By loc = By.CssSelector(".mb-3");

      
      private  By invis = By.CssSelector(".ng-tns-c31-0");
        public IList<IWebElement> products()
        {
            waitForElements(loc);
            return pros;
        }

        public IWebElement selectProduct(String P_Name)
        {
           IWebElement pro= products().Where( p => p.FindElement(By.CssSelector("b")).Text.Contains(P_Name)).FirstOrDefault();

            return pro;
        }

        public CheckoutPage AddToCart(String P_Name)
        {
            selectProduct(P_Name).FindElement(By.CssSelector(".card-body button:last-of-type")).Click();
            waitForElements1(invis);

            cart.Click();
            CheckoutPage c=new CheckoutPage(d);
            return c;

        }
    }
}
