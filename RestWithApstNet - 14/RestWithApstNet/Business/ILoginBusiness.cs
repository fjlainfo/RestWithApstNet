using RestWithApstNet.Data.VO;
using RestWithApstNet.Model;
using System.Collections.Generic;

namespace RestWithApstNet.Business
{
    public interface ILoginBusiness
    {
         object FindByLogin(User user);
    }
}
