using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeadApp
{
    public interface IDataStore<T>
    {
        Task<bool> AddLeadAsync(T lead);
        Task<bool> UpdateLeadAsync(T lead);
        Task<bool> DeleteLeadAsync(string id);
        Task<T> GetLeadAsync(string id);
        Task<IEnumerable<T>> GetLeadsAsync(bool forceRefresh = false);
    }
}
