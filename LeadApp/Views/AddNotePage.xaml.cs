using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LeadApp
{
    public partial class AddNotePage : ContentPage
    {
        AddNoteViewModel viewModel;
        public AddNotePage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        public AddNotePage(Lead input)
        {
            InitializeComponent();

            var model = new AddNoteViewModel(input);

            BindingContext = model = viewModel;
        }

        void SaveNote_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }


        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            dpRemindDate.Date = DateTime.UtcNow.AddDays(3);
			dpRemindDate.IsVisible = e.Value;

        }
    }
}
