using FluentAutomation.Interfaces;
using System;

namespace BDDTests.Pages.SkyBill.Sections
{
    public class Calls
    {
        private readonly IActionSyntaxProvider I;
        private const string CallsSectionSelector = "section[data-calls-summary]";

        public Calls(IActionSyntaxProvider i)
        {
            I = i;
            I.Expect.Exists(CallsSectionSelector);
        }

        private const string Header = "section[data-calls-summary] header";
        private const string HeaderTotal = "section[data-calls-summary] header span[data-total]";
        private const string Details = "section[data-calls-summary] div[data-summary-details]";
        private const string DetailsItems = "section[data-calls-summary] div[data-summary-details] div[data-items] div[data-item]";
        private const string DetailsTotal = "section[data-calls-summary] div[data-summary-details] div[data-summary-total] span[data-total]";

        public Calls SectionHeaderClick()
        {
            I.Click(Header);
            return this;
        }

        public Calls SectionHeaderTotalVisible()
        {
            I.Expect.Visible(HeaderTotal);
            return this;
        }

        public Calls SectionHeaderTotalHidden()
        {
            I.Expect.Not.Visible(HeaderTotal);
            return this;
        }

        public Calls SectionHeaderTotal(Decimal value)
        {
            return SectionHeaderTotal(value.ToString("C"));
        }

        public Calls SectionHeaderTotal(String value)
        {
            I.Expect.Value(value).In(HeaderTotal);
            return this;
        }

        public Calls SectionDetailsVisible()
        {
            I.Expect.Visible(Details);
            return this;
        }

        public Calls SectionDetailsHidden()
        {
            I.Expect.Not.Visible(Details);
            return this;
        }
        
        public Calls SectionDetailsItemsCount(Int32 count)
        {
            I.Expect.Count(count).Of(DetailsItems);
            return this;
        }

        public Calls SectionDetailsTotal(Decimal value)
        {
            return SectionDetailsTotal(value.ToString("C"));
        }

        public Calls SectionDetailsTotal(String value)
        {
            I.Expect.Value(value).In(DetailsTotal);
            return this;
        }
    }
}
