using RestWithApstNet.Model;
using System.Collections.Generic;

namespace RestWithApstNet.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
