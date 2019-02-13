using RestWithApstNet.Data.VO;
using RestWithApstNet.Model;
using System.Collections.Generic;

namespace RestWithApstNet.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO PersonVO);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO PersonVO);
        void Delete(long id);
    }
}
