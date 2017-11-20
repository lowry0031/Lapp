using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeadApp
{
    public class LeadDetailViewModel : BaseViewModel
    {
        INavigation nav;
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? LastContacted { get; set; }
        public ICommand AddNoteCommand { get; private set; }

        public Lead Lead { get; set; }

        public LeadDetailViewModel(INavigation _nav,Lead lead = null)
        {
            nav = _nav;
            Title = lead?.FirstName + " " + lead?.LastName;
            Phone = lead?.Phone;
            Email = lead?.Email;
            LastContacted = DateTime.UtcNow;
            Lead = lead;
            AddNoteCommand = new Command(async () => await LoadAddNotePage(lead),() => !IsBusy);
        }

        public async Task LoadAddNotePage(Lead lead)
        {
            await nav.PushAsync(new AddNotePage(lead));
        }

    }
}
