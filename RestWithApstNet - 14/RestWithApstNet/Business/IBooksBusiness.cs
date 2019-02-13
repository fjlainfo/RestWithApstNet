using RestWithApstNet.Data.VO;
using RestWithApstNet.Model;
using System.Collections.Generic;

namespace RestWithApstNet.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
