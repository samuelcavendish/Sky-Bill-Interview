using BDDTests.Pages.SkyBill;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.Tests
{
    [Binding]
    public class AccordiansSteps : FluentTest
    {
        private SkyBillPage billPage;
        public AccordiansSteps()
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

        [When(@"I click the Subscription header")]
        public void WhenIClickTheSubscriptionHeader()
        {
            billPage.SubscriptionSection().SectionHeaderClick();
        }

        [When(@"I click the Calls header")]
        public void WhenIClickTheCallsHeader()
        {
            billPage.CallsSection().SectionHeaderClick();
        }

        [When(@"I click the Store Purchases header")]
        public void WhenIClickTheStorePurchasesHeader()
        {
            billPage.StoreSection().SectionHeaderClick();
        }

        [Then(@"the Subscription accordian should be closed")]
        public void ThenTheSubscriptionAccordianShouldBeClosed()
        {
            billPage.SubscriptionSection().SectionDetailsHidden();
        }

        [Then(@"the Subscription header total should be visible")]
        public void ThenTheSubscriptionHeaderTotalShouldBeVisible()
        {
            billPage.SubscriptionSection().SectionHeaderTotalVisible();
        }

        [Then(@"the Subscription total should equal £(.*)")]
        public void ThenTheSubscriptionTotalShouldEqual(Decimal p0)
        {
            billPage.SubscriptionSection().SectionDetailsTotal(p0);
        }

        [Then(@"the Subscription details should be hidden")]
        public void ThenTheSubscriptionDetailsShouldBeHidden()
        {
            billPage.SubscriptionSection().SectionDetailsHidden();
        }

        [Then(@"the Calls accordian should be closed")]
        public void ThenTheCallsAccordianShouldBeClosed()
        {
            billPage.CallsSection().SectionDetailsHidden();
        }

        [Then(@"the Calls header total should be visible")]
        public void ThenTheCallsHeaderTotalShouldBeVisible()
        {
            billPage.CallsSection().SectionHeaderTotalHidden();
        }

        [Then(@"the Calls total should equal £(.*)")]
        public void ThenTheCallsTotalShouldEqual(Decimal p0)
        {
            billPage.CallsSection().SectionDetailsTotal(p0);
        }

        [Then(@"the Calls details should be hidden")]
        public void ThenTheCallsDetailsShouldBeHidden()
        {
            billPage.CallsSection().SectionDetailsHidden();
        }

        [Then(@"the Store Purchases accordian should be closed")]
        public void ThenTheStorePurchasesAccordianShouldBeClosed()
        {
            billPage.StoreSection().SectionDetailsHidden();
        }

        [Then(@"the Store header Purchases total should be visible")]
        public void ThenTheStoreHeaderPurchasesTotalShouldBeVisible()
        {
            billPage.StoreSection().SectionHeaderTotalVisible();
        }

        [Then(@"the Store Purchases total should equal £(.*)")]
        public void ThenTheStorePurchasesTotalShouldEqual(Decimal p0)
        {
            billPage.StoreSection().SectionDetailsTotal(p0);
        }

        [Then(@"the Store details should be hidden")]
        public void ThenTheStoreDetailsShouldBeHidden()
        {
            billPage.StoreSection().SectionDetailsHidden();
        }

        [Then(@"the Subscription accordian should be open")]
        public void ThenTheSubscriptionAccordianShouldBeOpen()
        {
            billPage.SubscriptionSection().SectionDetailsVisible();
        }

        [Then(@"the Subscription header total should be hidden")]
        public void ThenTheSubscriptionHeaderTotalShouldBeHidden()
        {
            billPage.SubscriptionSection().SectionHeaderTotalHidden();
        }

        [Then(@"the Subscription details should be visible")]
        public void ThenTheSubscriptionDetailsShouldBeVisible()
        {
            billPage.SubscriptionSection().SectionDetailsVisible();
        }

        [Then(@"the Calls header total should be hidden")]
        public void ThenTheCallsHeaderTotalShouldBeHidden()
        {
            billPage.CallsSection().SectionHeaderTotalHidden();
        }

        [Then(@"the Calls details should be visible")]
        public void ThenTheCallsDetailsShouldBeVisible()
        {
            billPage.CallsSection().SectionDetailsVisible();
        }

        [Then(@"the Calls details total should equal £(.*)")]
        public void ThenTheCallsDetailsTotalShouldEqual(Decimal p0)
        {
            billPage.CallsSection().SectionDetailsTotal(p0);
        }

        [Then(@"the Store Purchases header total should be hidden")]
        public void ThenTheStorePurchasesHeaderTotalShouldBeHidden()
        {
            billPage.StoreSection().SectionHeaderTotalHidden();
        }

        [Then(@"the Store Purchases details should be visible")]
        public void ThenTheStorePurchasesDetailsShouldBeVisible()
        {
            billPage.StoreSection().SectionDetailsVisible();
        }
    }
}
