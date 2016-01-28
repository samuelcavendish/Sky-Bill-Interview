using BDDTests.Pages.SkyBill.Sections;
using FluentAutomation;
using System;
using System.Configuration;

namespace BDDTests.Pages.SkyBill
{
    public class SkyBillPage : PageObject<SkyBillPage>
    {
        public SkyBillPage(FluentTest test) : base(test)
        {
            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            Url = baseUrl;
            At = () => I.WaitUntil(() => I.Assert.Exists(Body));
        }

        private const string Body = "body";
        private const string HeaderBar = "body > header div[data-header-bar]";
        private const string Main = "body main";
        private const string FromDate = "body main h2 [data-from-date]";
        private const string ToDate = "body main h2 [data-to-date]";
        private const string BillSummaryAmount = "body main section[data-bill-summary] [data-amount]";
        private const string DueDate = "body main section[data-bill-summary] [data-due-date]";
        private const string StatementDate = "body main div [data-statement-date]";

        private Subscription subscription;
        public Subscription SubscriptionSection()
        {
            return subscription ?? (subscription = new Subscription(I));
        }

        private Calls calls;
        public Calls CallsSection()
        {
            return calls ?? (calls = new Calls(I));
        }

        private Store store;
        public Store StoreSection()
        {
            return store ?? (store = new Store(I));
        }

        private Navigation navigation;
        public Navigation Navigation()
        {
            return navigation ?? (navigation = new Navigation(I));
        }

        public SkyBillPage HeaderBarClick()
        {
            I.Click(HeaderBar);
            return this;
        }

        public SkyBillPage MainClick()
        {
            I.Click(Main);
            return this;
        }

        public SkyBillPage FromDateValue(String value)
        {
            I.Expect.Value(value).In(FromDate);
            return this;
        }

        public SkyBillPage ToDateValue(String value)
        {
            I.Expect.Value(value).In(FromDate);
            return this;
        }

        public SkyBillPage BillTotalValue(Decimal value)
        {
            return BillTotalValue(value.ToString("C"));
        }

        public SkyBillPage BillTotalValue(String value)
        {
            I.Expect.Value(value).In(BillSummaryAmount);
            return this;
        }

        public SkyBillPage DueDateValue(String value)
        {
            I.Expect.Value(value).In(DueDate);
            return this;
        }

        public SkyBillPage StatementDateValue(String value)
        {
            I.Expect.Value(value).In(StatementDate);
            return this;
        }
    }
}
