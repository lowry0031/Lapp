using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

using Plugin.Geolocator;

namespace LeadApp
{
    public partial class LeadMap : ContentPage
    {
        Map map;
        public LeadMap()
        {
            InitializeComponent();

            map = new Map()
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var stackLayout = new StackLayout { Spacing = 0 };
            stackLayout.Children.Add(map);
            Content = stackLayout;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                                             Distance.FromMiles(1)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

            }
        }
    }
}
