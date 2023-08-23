using EcomerceApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
//using SpecFlowProject2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp.StepDefinitions
{
    [Binding]
    public class Step
    {
        IWebDriver d;
        ProductCatalog p;
        CheckoutPage c;
        PlaceOrder pl;
        Orders o;
        ICommon Ic;

        public Step(IWebDriver d, ICommon Ic)
        {
            this.d = d;
            this.Ic = Ic;
        }

        [Given(@"The user is on the eCommerce website")]
        public void GivenTheUserIsOnTheECommerceWebsite()
        {
            // d=new FirefoxDriver();
        }
        [When(@"The User is login to eCommerce Application")]
        public void WhenTheUserIsLoginToECommerceApplication(Table table)
        {
            String email = table.Rows[0]["UserName"];
            String password = table.Rows[0]["Password"];
             //LoginPage l= new LoginPage(d);
             //p = l.LoginToEcom(email, password);
            p = Ic.login.LoginToEcom(email, password);
        }

        [When(@"The user select The product ""([^""]*)"" and adds it to the cart")]
        public void WhenTheUserSelectTheProductAndAddsItToTheCart(String product)
        {
            c = p.AddToCart(product);
        }


        [When(@"proceeds to checkout")]
        public void WhenProceedsToCheckout()
        {
            pl = c.ClickToChecout();
        }

        [When(@"Select country wirh ShortName ""([^""]*)"" and places the order")]
        public void WhenSelectCountryWirhShortNameAndPlacesTheOrder(String country)
        {
            pl.SearchCountry(country);
            o = pl.placeTheOrder();
        }


        [Then(@"the user should see an order confirmation with the Msg is ""([^""]*)""")]
        public void ThenTheUserShouldSeeAnOrderConfirmation(String _msg)
        {
            String msg = o.SuccessfulyOrdered();

            Assert.AreEqual(msg, _msg);

        }
    }

}

