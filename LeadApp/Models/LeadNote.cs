using System;
namespace LeadApp
{
    public class LeadNote
    {
        public string Id { get; set; }
		public string Notes { get; set; }
        public DateTime RemindDate { get; set; }
        public DateTime? CompletedDate { get; set; }

    }
}
