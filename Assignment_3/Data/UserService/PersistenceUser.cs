// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Models;
//
// namespace Assignment_3.Data
// {
//     public class PersistenceUser : IUserService
//     {
//         private IList<User> _users;
//
//         public PersistenceUser()
//         {
//             _users = SeeUsers();
//         }
//         
//         public async Task<IList<User>> GetUsers()
//         {
//             IList<User> users = new List<User>(_users);
//             return users;
//         }
//         
//         private IList<User> SeeUsers()
//         {
//             IList<User> users = JsonSerializer.Deserialize<IList<User>>(File.ReadAllText("users.json"));
//             return users;
//         }
//     }
// }