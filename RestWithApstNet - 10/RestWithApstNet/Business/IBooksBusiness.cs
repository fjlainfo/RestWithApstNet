using RestWithApstNet.Model;
using System.Collections.Generic;

namespace RestWithApstNet.Business
{
    public interface IBookBusiness
    {
        Book Create(Book person);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}
