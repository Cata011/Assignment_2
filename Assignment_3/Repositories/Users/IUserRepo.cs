using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment_3.Repositories
{
    public interface IUserRepo
    {
        Task<IList<User>> GetUsers();
        Task AddUserAsync(User user);
    }
}