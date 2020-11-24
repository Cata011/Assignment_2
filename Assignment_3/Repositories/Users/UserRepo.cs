using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_3.Context;
using Models;

namespace Assignment_3.Repositories
{
    public class UserRepo : IUserRepo
    {
        public async Task<IList<User>> GetUsers()
        {
            using (AdultDbContext context = new AdultDbContext())
            {
                return context.Users.ToList();
            }
        }

        public async Task AddUserAsync(User user)
        {
            using (AdultDbContext context = new AdultDbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }
    }
}