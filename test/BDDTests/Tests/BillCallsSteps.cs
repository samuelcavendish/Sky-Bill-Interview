using BDDTests.Pages.SkyBill;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.Tests
{
    [Binding]
    [Scope(Feature = "Bill Calls")]
    public class BillCallsSteps : FluentTest
    {
        private SkyBillPage billPage;
        public BillCallsSteps()
        {
            SeleniumWebDriver.Bootstrap(FluentAutomation.SeleniumWebDriver.Browser.Chrome);
            FluentSettings.Current.WaitTimeout = TimeSpan.FromSeconds(5);
            FluentSettings.Current.WaitUntilTimeout = TimeSpan.FromSeconds(30);
        }
        
        [Given(@"I am on the bill page")]
        public void GivenIAmOnTheBillPage()
        {
            billPage = new SkyBillPage(this).Go();
        }

        [Given(@"I am on the mobile bill page")]
        public void GivenIAmOnTheMobileBillPage()
        {
            GivenIAmOnTheBillPage();
            FluentSettings.Current.WindowWidth = 500;
            billPage.Navigation().MobileNavigationTriggerVisible();
        }

        [When(@"I click the call header")]
        public void WhenIClickTheCallHeader()
        {
            billPage.CallsSection().SectionHeaderClick();
        }
        
        [Then(@"the call details should be shown")]
        public void ThenTheCallDetailsShouldBeShown()
        {
            billPage.CallsSection().SectionDetailsVisible();
        }
        
        [Then(@"the call total in the header should be hidden")]
        public void ThenTheCallTotalInTheHeaderShouldBeHidden()
        {
            billPage.CallsSection().SectionHeaderTotalHidden();
        }
        
        [Then(@"there should be (.*) call items")]
        public void ThenThereShouldBeCallItems(int p0)
        {
            billPage.CallsSection().SectionDetailsItemsCount(p0);
        }
        
        [Then(@"a total value in the call details of £(.*)")]
        public void ThenATotalValueInTheCallDetailsOf(Decimal p0)
        {
            billPage.CallsSection().SectionDetailsTotal(p0);
        }
    }
}
