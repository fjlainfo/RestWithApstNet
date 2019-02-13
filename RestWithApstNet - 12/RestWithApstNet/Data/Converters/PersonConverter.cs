using RestWithApstNet.Data.Converter;
using RestWithApstNet.Data.VO;
using RestWithApstNet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithApstNet.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO orgin)
        {
            if (orgin == null) return new Person();
            return new Person
            {
                Id = orgin.Id,
                FirstName = orgin.FirstName,
                LastName = orgin.LastName,
                Address = orgin.Address,
                Gender = orgin.Gender
            };
        }

        public PersonVO Parse(Person orgin)
        {
            if (orgin == null) return new PersonVO();
            return new PersonVO
            {
                Id = orgin.Id,
                FirstName = orgin.FirstName,
                LastName = orgin.LastName,
                Address = orgin.Address,
                Gender = orgin.Gender
            };
        }

        public List<Person> ParseList(List<PersonVO> orgin)
        {
            if (orgin == null) return new List<Person>();
            return orgin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> orgin)
        {
            if (orgin == null) return new List<PersonVO>();
            return orgin.Select(item => Parse(item)).ToList();
        }
    }
}
