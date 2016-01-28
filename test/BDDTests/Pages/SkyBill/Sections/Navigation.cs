using FluentAutomation.Interfaces;

namespace BDDTests.Pages.SkyBill.Sections
{
    public class Navigation
    {
        private readonly IActionSyntaxProvider I;
        private const string NavigationSectionSelector = "body > header nav";

        public Navigation(IActionSyntaxProvider i)
        {
            I = i;
            I.Expect.Exists(NavigationSectionSelector);
        }

        private const string MobileNavigationTrigger = "body > header a[data-trigger=\"navigation\"]";

        public Navigation MobileNavigationTriggerVisible()
        {
            I.Expect.Visible(MobileNavigationTrigger);
            return this;
        }

        public Navigation ClickMobileNavigationTrigger()
        {
            I.Expect.Visible(MobileNavigationTrigger);
            I.Click(MobileNavigationTrigger);
            return this;
        }

        public Navigation NavigationVisable()
        {
            I.Expect.Visible(NavigationSectionSelector);
            return this;
        }

        public Navigation NavigationHidden()
        {
            I.Expect.Visible(NavigationSectionSelector);
            return this;
        }
    }
}
