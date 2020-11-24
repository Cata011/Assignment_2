using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment_3.Repositories
{
    public interface IAdultRepo
    {
        Task<IList<Adult>> ReadAllAdultsAsync(int? id, string? firstName, string? sex);
        Task AddAdultAsync(Adult adult);
        Task UpdateAdultAsync(int Id, Adult adultToUpdate);
        Task DeleteAdultAsync(int adultId);
    }
}