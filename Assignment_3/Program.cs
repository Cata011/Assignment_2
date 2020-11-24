using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_3.Context;
using Assignment_3.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;

namespace Assignment_3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("build");
            Console.WriteLine("run");
            // AdultRepo repo = new AdultRepo();
            // Adult a1 = new Adult
            // {
            //     JobTitle= "Database Manager",
            //     Id= 2,
            //     FirstName= "ssssssss111222333",
            //     LastName= "Magana",
            //     HairColor= "Black",
            //     EyeColor= "Blue",
            //     Age= 44,
            //     Weight= 61.4f,
            //     Height= 166,
            //     Sex= "M"
            // };
            //
            // repo.AddAdultAsync(a1);
            // Console.WriteLine("dupa run");
            
            UserRepo repo = new UserRepo();
            User u1 = new User
            {
                UserName = "level1",
                SecurityLevel = 1,
                Password = "12345"
            };
            
            await repo.AddUserAsync(u1);



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}