using System;

namespace LeadApp
{
    public class AddNoteViewModel : BaseViewModel
    {
		public string Id { get; set; }
        public string Notes { get; set; }
        public DateTime? RemindDate { get; set; }
        public bool RemindLater { get; set; }


        public AddNoteViewModel(Lead lead = null)
        {
            Title = "Add Note for " + lead?.FirstName + " " + lead?.LastName;
            RemindDate = DateTime.UtcNow.AddDays(3);
        }
    }
}
