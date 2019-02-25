using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithApstNet.Model;
using RestWithApstNet.Model.Context;

namespace RestWithApstNet.Repository.Implementattions
{
    public class UserRepositoryImpl : IUserRepository
    {
        private MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}



