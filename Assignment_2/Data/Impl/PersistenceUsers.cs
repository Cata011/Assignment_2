// ﻿using System;
// using System.Collections.Generic;
// using System.Linq;
// using FileData;
// using Models;
//
// namespace Assignment1.Data.Impl
// {
//     public class PersistenceUsers : IUserService
//     {
//         private UsersFileContext _usersFileContext;
//
//         public PersistenceUsers()
//         {
//             _usersFileContext = new UsersFileContext();
//         }
//         
//         public User ValidateUser(string userName, string password)
//         {
//             IList<User> users = _usersFileContext.Users;
//             User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
//             if (first == null) {
//                 throw new Exception("User not found");
//             }
//
//             if (!first.Password.Equals(password)) {
//                 throw new Exception("Incorrect password");
//             }
//
//             return first;
//         }
//     }
// }