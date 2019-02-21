﻿using SIS_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_API.Service
{
    public class UserService
    {
        UserRepository repository = new UserRepository();
        public User InsertUser(User user)
        {
            return repository.Insert(user);
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll<User>();
        }

        public User GetByUsername(string username)
        {
            return repository.Get(username);
        }

        public void Update(User user)
        {
            User origin = repository.Get(user.Username);
            origin.Password = user.Password;
            origin.Name = user.Name;
            repository.Update(origin);
        }

        public void Delete(string username)
        {
            User origin = repository.Get(username);
            origin.Status = 0;
            repository.Update(origin);
        }
    }
}