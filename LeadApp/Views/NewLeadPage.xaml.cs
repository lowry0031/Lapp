using System;
using Xamarin.Forms;

namespace LeadApp
{
    public partial class NewLeadPage : ContentPage
    {
        public Lead Lead { get; set; }

        public NewLeadPage()
        {
            InitializeComponent();

            Lead = new Lead();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Lead);
            await Navigation.PopToRootAsync();
        }
    }
}
