using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace LeadApp
{
    public class CloudDataStore : IDataStore<Lead>
    {
        HttpClient client;
        IEnumerable<Lead> leads;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            leads = new List<Lead>();
        }

        public async Task<IEnumerable<Lead>> GetLeadsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/lead");
                leads = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Lead>>(json));
            }

            return leads;
        }

        public async Task<Lead> GetLeadAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/lead/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Lead>(json));
            }

            return null;
        }

        public async Task<bool> AddLeadAsync(Lead lead)
        {
            if (lead == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedLead = JsonConvert.SerializeObject(lead);

            var response = await client.PostAsync($"api/lead", new StringContent(serializedLead, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateLeadAsync(Lead lead)
        {
            if (lead == null || lead.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedLead = JsonConvert.SerializeObject(lead);
            var buffer = Encoding.UTF8.GetBytes(serializedLead);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/lead/{lead.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLeadAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/lead/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
