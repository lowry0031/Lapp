using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LeadApp
{
    public partial class LeadsPage : ContentPage
    {
        LeadsViewModel viewModel;

        public LeadsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LeadsViewModel(this.Navigation);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var lead = args.SelectedItem as LeadDetailViewModel;
            if (lead == null)
                return;

            await Navigation.PushAsync(new LeadDetailPage(lead));

            // Manually deselect item
            LeadsListView.SelectedItem = null;
        }

        async void AddLead_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewLeadPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Leads.Count == 0)
                viewModel.LoadLeadsCommand.Execute(null);
        }
    }
}
