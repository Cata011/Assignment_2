using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_3.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Assignment_3.Repositories
{
    public class AdultRepo : IAdultRepo
    {
        public async Task AddAdultAsync(Adult adultToAdd)
        {
            using (AdultDbContext context = new AdultDbContext())
            {
                Console.WriteLine("inainte");
               await context.Adults.AddAsync(adultToAdd);
               Console.WriteLine("dupa");
               await context.SaveChangesAsync();
            }
        }

        public async Task<IList<Adult>> ReadAllAdultsAsync(int? id, string? firstName, string? sex)
        {
            using (AdultDbContext context = new AdultDbContext())
            {
                IList<Adult> adults = context.Adults.ToList();
                if (id != null)
                {
                    adults = adults.Where(adult => adult.Id == id).ToList();
                }

                if (firstName != null)
                {
                    adults = adults.Where(adult => adult.FirstName.Equals(firstName)).ToList();
                }
            
                if (sex != null)
                {
                    adults = adults.Where(adult => adult.Sex.Equals(sex)).ToList();
                }
            
                if (id != null && firstName != null)
                {
                    adults = adults.Where(adult => adult.Id == id && adult.FirstName.Equals(firstName)).ToList();
                }
            
                if (sex != null && firstName != null)
                {
                    adults = adults.Where(adult => adult.Sex.Equals(sex) && adult.FirstName.Equals(firstName)).ToList();
                }
            
                if (id != null && firstName != null && sex != null)
                {
                    adults = adults.Where(adult => adult.Id == id && adult.FirstName.Equals(firstName) && adult.Sex.Equals(sex)).ToList();
                }

                return adults;
            }
        }

        public async Task UpdateAdultAsync(int Id, Adult adultToUpdate)
        {
            using (AdultDbContext context = new AdultDbContext())
            {
                context.Adults.Update(adultToUpdate);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAdultAsync(int adultId)
        {
            using (AdultDbContext context = new AdultDbContext())
            { 
                context.Adults.Remove(context.Adults.First(a => a.Id == adultId));
                await context.SaveChangesAsync();
            }
        }
    }
}