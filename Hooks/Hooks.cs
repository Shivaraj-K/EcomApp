using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using EcomerceApp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
///using SpecFlowProject2.Pages;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace EcomerceApp.Hooks
{
    [Binding]
    public sealed class Hooks : Extent
    {
        private readonly IObjectContainer _container;
        IWebDriver d;
        ICommon Ic;
      //  DriverIn dd;

        public Hooks(IObjectContainer container)
        {
            _container = container; 
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // dd = new DriverIn();
            //d = new FirefoxDriver();
            //d.Url = "https://rahulshettyacademy.com/client";
            //d.Manage().Window.Maximize();
            //d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver dd = new Driver();
           d= dd.DriverInIt();
            _container.RegisterInstanceAs<IWebDriver>(d);

            Ic = new CommonClass(d);
            _container.RegisterInstanceAs<ICommon>(Ic);
            T = et.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void ExtendMethod()
        {
            ExtentMethod();
        }

        [AfterTestRun]
        public static void TearDown()
        {
            ExtentTearDown();
        }
        [BeforeFeature]
        public static void FeatureMethod(FeatureContext fc)
        {
            et = e.CreateTest<Feature>(fc.FeatureInfo.Title);
        }

        //    [AfterScenario]
        //public void AfterScenario()
        //{
        //    //TODO: implement logic that has to run after executing each scenario
        //}

        [AfterStep]
        public void ReportMethod(ScenarioContext s)
        {
            String type = s.StepContext.StepInfo.StepDefinitionType.ToString();
            String _name = s.StepContext.StepInfo.Text;

            var d = _container.Resolve<IWebDriver>();

            if (s.TestError == null)
            {
                if (type == "Given")
                {
                    T.CreateNode<Given>(_name);
                }
                else if (type == "When")
                {
                    T.CreateNode<When>(_name);
                }

                else if (type == "Then")
                {
                    T.CreateNode<Then>(_name);
                }
            }

            else if (s.TestError != null)
            {
                if (type == "Given")
                {
                    T.CreateNode<When>(_name).Fail(s.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShot(d, s)).Build());
                }
                else if (type == "When")
                {
                    T.CreateNode<When>(_name).Fail(s.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShot(d, s)).Build());

                }

                else if (type == "Then")
                {
                    T.CreateNode<Then>(_name).Fail(s.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShot(d, s)).Build());
                }
            }

        }
    }
}