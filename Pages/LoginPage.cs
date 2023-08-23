using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceApp.Pages
{
    public class LoginPage
    {
        IWebDriver d;

        public LoginPage(IWebDriver d) 
        {
            this.d = d;
            PageFactory.InitElements(d, this);
        }

        [FindsBy(How=How.Id,Using = "userEmail")]
        private IWebElement _email { get; set; }


        [FindsBy(How = How.Id, Using = "userPassword")]
        private IWebElement pass { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement login { get; set; }


        public ProductCatalog LoginToEcom(String email,String password)
        {
            _email.SendKeys(email);
            pass.SendKeys(password);
            login.Click();

            return new ProductCatalog(d);
        }

    }
}
