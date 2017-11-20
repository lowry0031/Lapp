using System;

using Xamarin.Forms;

namespace LeadApp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, mapPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    itemsPage = new NavigationPage(new LeadsPage())
                    {
                        Title = "Leads"
                    };

                    mapPage = new NavigationPage(new LeadMap())
                    {
                        Title = "Map",
                        Icon = "tab_feed.png"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    itemsPage = new LeadsPage()
                    {
                        Title = "Leads"
                    };

                    mapPage = new LeadMap()
                    {
                        Title = "Map"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(mapPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
