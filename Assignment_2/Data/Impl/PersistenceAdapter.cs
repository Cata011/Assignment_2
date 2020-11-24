// ﻿using System;
// using System.Collections.Generic;
// using System.Linq;
// using FileData;
// using Microsoft.AspNetCore.Components.Rendering;
// using Models;
//
// namespace Assignment1.Data.Impl
// {
//     public class PersistenceAdapter : IAdultService
//     {
//
//         private FileContext file;
//
//         public PersistenceAdapter()
//         {
//             file = new FileContext();
//         }
//
//         public void AddAdult(Adult adultToAdd)
//         {
//             int max = file.Adults.Max(a => a.Id);
//             adultToAdd.Id = (++max);
//             file.Adults.Add(adultToAdd);
//             file.SaveChanges();
//         }
//
//         public IList<Adult> ReadAllAdults()
//         {
//             return file.Adults;
//         }
//
//         public void UpdateAdult(Adult adultToUpdate)
//         {
//             foreach (var adult in file.Adults)
//             {
//                 if (adult.Id == adultToUpdate.Id)
//                 {
//                     adult.Update(adultToUpdate);
//                     file.SaveChanges();
//                     return;
//                 }
//             }
//         }
//
//         public void DeleteAdult(Adult adultToDelete)
//         {
//             foreach (var adult in file.Adults)
//             {
//                 if (adult.Id == adultToDelete.Id)
//                 {
//                     file.Adults.Remove(adult);
//                     file.SaveChanges();
//                     return;
//                 }
//             }
//         }
//     }
// }