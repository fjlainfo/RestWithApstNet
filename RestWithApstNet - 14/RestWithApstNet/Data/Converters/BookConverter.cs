using RestWithApstNet.Data.Converter;
using RestWithApstNet.Data.VO;
using RestWithApstNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithApstNet.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO orgin)
        {
            if (orgin == null) return new Book();
            return new Book
            {
                Id = orgin.Id,
                Title = orgin.Title,
                Author = orgin.Author,
                LanchDate = orgin.LanchDate,
                price = orgin.price
            };
        }

        public BookVO Parse(Book orgin)
        {
            if (orgin == null) return new BookVO();
            return new BookVO
            {
                Id = orgin.Id,
                Title = orgin.Title,
                Author = orgin.Author,
                LanchDate = orgin.LanchDate,
                price = orgin.price
            };
        }

        public List<Book> ParseList(List<BookVO> orgin)
        {
            if (orgin == null) return new List<Book>();
            return orgin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> ParseList(List<Book> orgin)
        {
            if (orgin == null) return new List<BookVO>();
            return orgin.Select(item => Parse(item)).ToList();
        }
    }
}
