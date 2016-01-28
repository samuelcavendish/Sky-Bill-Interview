using BDDTests.Pages.SkyBill.Sections;
using FluentAutomation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SkyBillPage ClickHeaderBar()
        {
            I.Click(HeaderBar);
            return this;
        }

        public SkyBillPage ClickMain()
        {
            I.Click(Main);
            return this;
        }
    }
}
