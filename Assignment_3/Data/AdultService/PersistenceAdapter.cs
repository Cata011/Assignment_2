// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Models;
//
// namespace Assignment1.Data.Impl
// {
//     public class PersistenceAdapter : IAdultService
//     {
//         private IList<Adult> _adults;
//
//         public PersistenceAdapter()
//         {
//             _adults = SeeAdults();
//             WriteToFile();
//         }
//         
//         public async Task AddAdultAsync(Adult adultToAdd)
//         {
//             int max = _adults.Max(adultToAdd => adultToAdd.Id);
//             adultToAdd.Id = ++max;
//             _adults.Add(adultToAdd);
//             WriteToFile();
//         }
//
//         public async Task<IList<Adult>> ReadAllAdultsAsync( int? id, string? firstName, string? sex)
//         {
//             IList<Adult> adults = new List<Adult>(_adults);
//             if (id != null)
//             {
//                 adults = adults.Where(adult => adult.Id == id).ToList();
//             }
//
//             if (firstName != null)
//             {
//                 adults = adults.Where(adult => adult.FirstName.Equals(firstName)).ToList();
//             }
//             
//             if (sex != null)
//             {
//                 adults = adults.Where(adult => adult.Sex.Equals(sex)).ToList();
//             }
//             
//             if (id != null && firstName != null)
//             {
//                 adults = adults.Where(adult => adult.Id == id && adult.FirstName.Equals(firstName)).ToList();
//             }
//             
//             if (sex != null && firstName != null)
//             {
//                 adults = adults.Where(adult => adult.Sex.Equals(sex) && adult.FirstName.Equals(firstName)).ToList();
//             }
//             
//             if (id != null && firstName != null && sex != null)
//             {
//                 adults = adults.Where(adult => adult.Id == id && adult.FirstName.Equals(firstName) && adult.Sex.Equals(sex)).ToList();
//             }
//           
//             return adults;
//         }
//
//         public async Task UpdateAdultAsync(int Id, Adult adultToUpdate)
//         {
//             Adult toUpdate = _adults.First(t => t.Id == Id);
//             // if(toUpdate == null) throw new Exception($"Did not find adult with id: {adultToUpdate.Id}");
//             Console.WriteLine(toUpdate);
//             toUpdate.Update(adultToUpdate);
//             Console.WriteLine(toUpdate);
//             WriteToFile();
//         }
//
//         public async Task DeleteAdultAsync(int adultId)
//         {
//             Adult toRemove = _adults.First(t => t.Id == adultId);
//             _adults.Remove(toRemove);
//             WriteToFile();
//         }
//
//         private void WriteToFile()
//         {
//             string adultsAsJson = JsonSerializer.Serialize(_adults);
//             File.WriteAllText("adults.json", adultsAsJson);
//         }
//
//         private IList<Adult> SeeAdults()
//         {
//             IList<Adult> adults = JsonSerializer.Deserialize<IList<Adult>>(File.ReadAllText("adults.json"));
//             return adults;
//         }
//     }
// }