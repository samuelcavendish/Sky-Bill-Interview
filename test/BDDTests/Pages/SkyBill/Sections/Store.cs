﻿using FluentAutomation;
using FluentAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDTests.Pages.SkyBill.Sections
{
    public class Store
    {
        private readonly IActionSyntaxProvider I;
        private const string StoreSectionSelector = "section[data-store-summary]";

        public Store(IActionSyntaxProvider i)
        {
            I = i;
            I.Expect.Exists(StoreSectionSelector);
        }

        private const string Header = "section[data-store-summary] header";
        private const string HeaderTotal = "section[data-store-summary] header span[data-total]";
        private const string Details = "section[data-store-summary] div[data-summary-details]";
        private const string DetailsItems = "section[data-store-summary] div[data-summary-details] div[data-items] div[data-item]";
        private const string DetailsTotal = "section[data-store-summary] div[data-summary-details] div[data-summary-total] span[data-total]";

        public Store SectionHeaderClick()
        {
            I.Click(Header);
            return this;
        }

        public Store SectionHeaderTotalVisible()
        {
            I.Expect.Visible(HeaderTotal);
            return this;
        }

        public Store SectionHeaderTotalHidden()
        {
            I.Expect.Not.Visible(HeaderTotal);
            return this;
        }

        public Store SectionHeaderTotal(Decimal value)
        {
            return SectionHeaderTotal(value.ToString("C"));
        }

        public Store SectionHeaderTotal(String value)
        {
            I.Expect.Value(value).In(HeaderTotal);
            return this;
        }

        public Store SectionDetailsVisible()
        {
            I.Expect.Visible(Details);
            return this;
        }

        public Store SectionDetailsHidden()
        {
            I.Expect.Not.Visible(Details);
            return this;
        }
        
        public Store SectionDetailsItemsCount(Int32 count)
        {
            I.Expect.Count(count).Of(DetailsItems);
            return this;
        }

        public Store SectionDetailsTotal(Decimal value)
        {
            return SectionDetailsTotal(value.ToString("C"));
        }

        public Store SectionDetailsTotal(String value)
        {
            I.Expect.Value(value).In(DetailsTotal);
            return this;
        }
    }
}
