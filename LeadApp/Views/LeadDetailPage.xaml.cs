using System;
using Plugin.Messaging;
using Xamarin.Forms;

namespace LeadApp
{
    public partial class LeadDetailPage : ContentPage
    {
        LeadDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public LeadDetailPage()
        {
            InitializeComponent();


            BindingContext = viewModel;
        }

        public LeadDetailPage(LeadDetailViewModel viewModel)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty((viewModel.Lead.Phone)))
            {
                var call = new TapGestureRecognizer();

                call.Tapped += (s, e) =>
                {
                    var phoneDialer = CrossMessaging.Current.PhoneDialer;
                    if (phoneDialer.CanMakePhoneCall)
                        phoneDialer.MakePhoneCall(viewModel.Lead.Phone);
                    else
                        DisplayAlert("Cannot call", viewModel.Lead.Phone, "Got it");
                };
                var phoneLink = new Image()
                {
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
                phoneLink.GestureRecognizers.Add(call);

                if (Device.RuntimePlatform == Device.iOS)
                    phoneLink.Source = "tab_about.png";
                else if (Device.RuntimePlatform == Device.Android)
                    phoneLink.Source = "tab_about.png";

                stkPhone.Children.Add(phoneLink);
            }

            if (!string.IsNullOrEmpty((viewModel.Lead.Email)))
            {

                var email = new TapGestureRecognizer();

                email.Tapped += (s, e) =>
                {
                    var emailClient = CrossMessaging.Current.EmailMessenger;
                    if (emailClient.CanSendEmail)
                        emailClient.SendEmail(viewModel.Lead.Email);
                    else
                        DisplayAlert("Cannot Email", viewModel.Lead.Email, "Got it");
                };

                var emailLink = new Image()
                {
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
                emailLink.GestureRecognizers.Add(email);

                if (Device.RuntimePlatform == Device.iOS)
                    emailLink.Source = "tab_about.png";
                else if (Device.RuntimePlatform == Device.Android)
                    emailLink.Source = "tab_about.png";

                stkEmail.Children.Add(emailLink);
            }

            BindingContext = this.viewModel = viewModel;
        }

    }
}
