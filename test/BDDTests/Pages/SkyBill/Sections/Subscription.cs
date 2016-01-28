using FluentAutomation;
using FluentAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDDTests.Pages.SkyBill.Sections
{
    public class Subscription
    {
        private readonly IActionSyntaxProvider I;
        private const string SubscriptionSectionSelector = "section[data-package-summary]";

        public Subscription(IActionSyntaxProvider i)
        {
            I = i;
            I.Expect.Exists(SubscriptionSectionSelector);
        }

        private const string Header = "section[data-package-summary] header";
        private const string HeaderTotal = "section[data-package-summary] header span[data-total]";
        private const string Details = "section[data-package-summary] div[data-summary-details]";
        private const string DetailsItems = "section[data-package-summary] div[data-summary-details] div[data-items] div[data-item]";
        private const string DetailsTotal = "section[data-package-summary] div[data-summary-details] div[data-summary-total] span[data-total]";

        public Subscription SectionHeaderClick()
        {
            I.Click(Header);
            return this;
        }

        public Subscription SectionHeaderTotalVisible()
        {
            I.Expect.Visible(HeaderTotal);
            return this;
        }

        public Subscription SectionHeaderTotalHidden()
        {
            I.Expect.Not.Visible(HeaderTotal);
            return this;
        }

        public Subscription SectionHeaderTotal(Decimal value)
        {
            return SectionHeaderTotal(value.ToString("C"));
        }

        public Subscription SectionHeaderTotal(String value)
        {
            I.Expect.Value(value).In(HeaderTotal);
            return this;
        }

        public Subscription SectionDetailsVisible()
        {
            I.Expect.Visible(Details);
            return this;
        }

        public Subscription SectionDetailsHidden()
        {
            I.Expect.Not.Visible(Details);
            return this;
        }
        
        public Subscription SectionDetailsItemsCount(Int32 count)
        {
            I.Expect.Count(count).Of(DetailsItems);
            return this;
        }

        public Subscription SectionDetailsTotal(Decimal value)
        {
            return SectionDetailsTotal(value.ToString("C"));
        }

        public Subscription SectionDetailsTotal(String value)
        {
            I.Expect.Value(value).In(DetailsTotal);
            return this;
        }
    }
}
