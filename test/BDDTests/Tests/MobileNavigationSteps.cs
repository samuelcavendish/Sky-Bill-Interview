using BDDTests.Pages.SkyBill;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.Tests
{
    [Binding]
    [Scope(Feature = "Mobile Navigation")]
    public class MobileNavigationSteps : FluentTest
    {
        private SkyBillPage billPage;
        public MobileNavigationSteps()
        {
            SeleniumWebDriver.Bootstrap(FluentAutomation.SeleniumWebDriver.Browser.Chrome);
            FluentSettings.Current.WaitTimeout = TimeSpan.FromSeconds(5);
            FluentSettings.Current.WaitUntilTimeout = TimeSpan.FromSeconds(30);
        }

        [Given(@"I am on the mobile bill page")]
        public void GivenIAmOnTheMobileBillPage()
        {
            billPage = new SkyBillPage(this).Go();
            FluentSettings.Current.WindowWidth = 500;
            billPage.Navigation().MobileNavigationTriggerVisible();
        }

        [Given(@"I have clicked the navigation trigger")]
        public void GivenIHaveClickedTheNavigationTrigger()
        {
            billPage.Navigation().ClickMobileNavigationTrigger();
        }
        
        [When(@"I click the navigation trigger")]
        public void WhenIClickTheNavigationTrigger()
        {
            billPage.Navigation().ClickMobileNavigationTrigger();
        }
        
        [When(@"I click the header bar")]
        public void WhenIClickTheHeaderBar()
        {
            billPage.ClickHeaderBar();
        }
        
        [When(@"I click in the main")]
        public void WhenIClickInTheMain()
        {
            billPage.ClickMain();
        }
        
        [Then(@"the navigation bar should be hidden")]
        public void ThenTheNavigationBarShouldBeHidden()
        {
            billPage.Navigation().NavigationHidden();
        }
        
        [Then(@"the navigation bar should show")]
        public void ThenTheNavigationBarShouldShow()
        {
            billPage.Navigation().NavigationVisable();
        }
        
        [Then(@"the navigation bar should hide")]
        public void ThenTheNavigationBarShouldHide()
        {
            billPage.Navigation().NavigationHidden();
        }
    }
}
