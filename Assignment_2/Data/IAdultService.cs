using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAdultService
    {
        Task AddAdultAsync(Adult adultToAdd);
        Task<IList<Adult>> ReadAllAdultsAsync(int? id, string? firstName, string? sex);
        
        Task<IList<Adult>> ReadAllAdultsAsync();
        Task UpdateAdultAsync(Adult adultToUpdate);
        Task DeleteAdultAsync(int adultToDeleteId);
    }
}