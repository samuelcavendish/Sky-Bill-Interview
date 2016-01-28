using BDDTests.Pages.SkyBill;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.Tests
{
    [Binding]
    public class BillSubscriptionsSteps : FluentTest
    {
        private SkyBillPage billPage;
        public BillSubscriptionsSteps()
        {
            SeleniumWebDriver.Bootstrap(FluentAutomation.SeleniumWebDriver.Browser.Chrome);
            FluentSettings.Current.WaitTimeout = TimeSpan.FromSeconds(5);
            FluentSettings.Current.WaitUntilTimeout = TimeSpan.FromSeconds(30);
        }

        [Given(@"that I visit the bill page")]
        public void GivenThatIVisitTheBillPage()
        {
            billPage = new SkyBillPage(this).Go();
        }

        [When(@"I click the subscription header")]
        public void WhenIClickTheSubscriptionHeader()
        {
            billPage.SubscriptionSection().SectionHeaderClick();
        }

        [Then(@"the subscription details should be shown")]
        public void ThenTheSubscriptionDetailsShouldBeShown()
        {
            billPage.SubscriptionSection().SectionDetailsVisible();
        }

        [Then(@"the subscription total in the header should be hidden")]
        public void ThenTheSubscriptionTotalInTheHeaderShouldBeHidden()
        {
            billPage.SubscriptionSection().SectionHeaderTotalHidden();
        }

        [Then(@"there should be (.*) subscription items")]
        public void ThenThereShouldBeSubscriptionItemsWithTheValues(int p0)
        {
            billPage.SubscriptionSection().SectionDetailsItemsCount(p0);
        }

        [Then(@"a total value in the details of £(.*)")]
        public void ThenATotalValueInTheDetailsOf(Decimal p0)
        {
            billPage.SubscriptionSection().SectionDetailsTotal(p0);
        }
    }
}
