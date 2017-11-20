using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadApp
{
    public class MockDataStore : IDataStore<Lead>
    {
        List<Lead> leads;

        public MockDataStore()
        {
            leads = new List<Lead>();
            var mockLeads = new List<Lead>
            {
                new Lead { Id = Guid.NewGuid().ToString(), FirstName = "Justin", LastName = "Smith",Email="justinlowry31@gmail.com",Phone="724-444-9239", Notes="This is an lead description." },
                new Lead { Id = Guid.NewGuid().ToString(), FirstName = "John", LastName = "Bryant",Phone="724-321-3422", Notes="This is an lead description." },
                new Lead { Id = Guid.NewGuid().ToString(), FirstName = "Sam", LastName = "Crosby",Phone="724-812-3111", Notes="This is an lead description." },
                new Lead { Id = Guid.NewGuid().ToString(), FirstName = "Ro", LastName = "McSmith",Phone="724-665-2342", Notes="This is an lead description." }
            };

            foreach (var lead in mockLeads)
            {
                leads.Add(lead);
            }
        }

        public async Task<bool> AddLeadAsync(Lead lead)
        {
            leads.Add(lead);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateLeadAsync(Lead lead)
        {
            var _lead = leads.Where((Lead arg) => arg.Id == lead.Id).FirstOrDefault();
            leads.Remove(_lead);
            leads.Add(lead);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteLeadAsync(string id)
        {
            var _lead = leads.Where((Lead arg) => arg.Id == id).FirstOrDefault();
            leads.Remove(_lead);

            return await Task.FromResult(true);
        }

        public async Task<Lead> GetLeadAsync(string id)
        {
            return await Task.FromResult(leads.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Lead>> GetLeadsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(leads);
        }
    }
}
