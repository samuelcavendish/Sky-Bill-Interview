using BDDTests.Pages.SkyBill;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.Tests
{
    [Binding]
    [Scope(Feature = "Totals")]
    public class TotalsSteps : FluentTest
    {
        private SkyBillPage billPage;
        public TotalsSteps()
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

        [Then(@"the Bill from date should be (.*)")]
        public void ThenTheBillFromDateShouldBe(string p0)
        {
            billPage.FromDateValue(p0);
        }

        [Then(@"the Bill to date should be (.*)")]
        public void ThenTheBillToDateShouldBe(string p0)
        {
            billPage.ToDateValue(p0);
        }

        [Then(@"the Subscription total should equal £(.*)")]
        public void ThenTheSubscriptionTotalShouldEqual(Decimal p0)
        {
            billPage.SubscriptionSection().SectionHeaderTotal(p0);
        }
        
        [Then(@"the Calls total should equal £(.*)")]
        public void ThenTheCallsTotalShouldEqual(Decimal p0)
        {
            billPage.CallsSection().SectionHeaderTotal(p0);
        }
        
        [Then(@"the Store Purchases total should equal £(.*)")]
        public void ThenTheStorePurchasesTotalShouldEqual(Decimal p0)
        {
            billPage.StoreSection().SectionHeaderTotal(p0);
        }
        
        [Then(@"the Total Due should be £(.*)")]
        public void ThenTheTotalDueShouldBe(Decimal p0)
        {
            billPage.BillTotalValue(p0);
        }

        [Then(@"the statement date should be (.*)")]
        public void ThenTheStatementDateShouldBe(string p0)
        {
            billPage.StatementDateValue(p0);
        }
    }
}
