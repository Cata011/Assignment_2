using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assignment1.Data.Impl
{
    public class CloudUserService : IUserService 
    {
        public async Task<User> ValidateUser(string userName, string password)
        {
            HttpClient httpClient = new HttpClient();
            string uri = "https://localhost:5001/users";
            string message = await httpClient.GetStringAsync(uri + $"?UserName={userName}&Password={password}");
            Console.WriteLine(message);
            IList<User> users = JsonSerializer.Deserialize<IList<User>>(message);
            User user = users.First(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            return user;

        }
    }
}