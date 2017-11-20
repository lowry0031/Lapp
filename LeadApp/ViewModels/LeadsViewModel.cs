using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LeadApp
{
    public class LeadsViewModel : BaseViewModel
    {
        INavigation nav;
        public ObservableCollection<LeadDetailViewModel> Leads { get; set; }
        public Command LoadLeadsCommand { get; set; }

        public LeadsViewModel(INavigation _nav)
        {
            nav = _nav;
            Title = "Leads";
            Leads = new ObservableCollection<LeadDetailViewModel>();
            LoadLeadsCommand = new Command(async () => await ExecuteLoadLeadsCommand());

            MessagingCenter.Subscribe<NewLeadPage, Lead>(this, "AddLead", async (obj, lead) =>
            {
                var _lead = lead as Lead;
                Leads.Add(new LeadDetailViewModel(nav,_lead));
                await DataStore.AddLeadAsync(_lead);
            });
        }

        async Task ExecuteLoadLeadsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Leads.Clear();
                var leads = await DataStore.GetLeadsAsync(true);
                foreach (var lead in leads)
                {
                    Leads.Add(new LeadDetailViewModel(nav,lead));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
