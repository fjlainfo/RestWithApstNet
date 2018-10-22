using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithApstNet.Model;
using RestWithApstNet.Model.Context;

namespace RestWithApstNet.Repository.Implementattions
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            } 
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            persons = _context.Persons.ToList();
            return persons;
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Add(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

    }
}



