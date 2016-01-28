using BDDTests.Pages.SkyBill;
using FluentAutomation;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.Tests
{
    [Binding]
    [Scope(Feature = "Bill Store")]
    public class BillStoreSteps : FluentTest
    {
        private SkyBillPage billPage;
        public BillStoreSteps()
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

        [When(@"I click the store header")]
        public void WhenIClickTheStoreHeader()
        {
            billPage.StoreSection().SectionHeaderClick();
        }
        
        [Then(@"the store details should be shown")]
        public void ThenTheStoreDetailsShouldBeShown()
        {
            billPage.StoreSection().SectionDetailsVisible();
        }
        
        [Then(@"the store total in the header should be hidden")]
        public void ThenTheStoreTotalInTheHeaderShouldBeHidden()
        {
            billPage.StoreSection().SectionHeaderTotalHidden();
        }
        
        [Then(@"there should be (.*) store rental item")]
        public void ThenThereShouldBeStoreRentalItem(int p0)
        {
            billPage.StoreSection().SectionDetailsRentalItemsCount(p0);
        }
        
        [Then(@"(.*) buy and keep items")]
        public void ThenBuyAndKeepItems(int p0)
        {
            billPage.StoreSection().SectionDetailsBuyAndKeepItemsCount(p0);
        }
        
        [Then(@"a total value in the store details of £(.*)")]
        public void ThenATotalValueInTheStoreDetailsOf(Decimal p0)
        {
            billPage.StoreSection().SectionDetailsTotal(p0);
        }
    }
}
