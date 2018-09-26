using System;
using System.Collections.Generic;
using System.Threading;
using RestWithApstNet.Model;

namespace RestWithApstNet.Services.Implementattions
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(i),
                FirstName = "Person FirstName " + i,
                LastName = "Person LastName " + i,
                Address = "SP - SP - Brasil " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet(int i)
        {
            return Interlocked.Increment(ref count);
        }
    
        public Person FindById(long id)
        {
            return new Person {
                Id = IncrementAndGet(1),
                FirstName = "Francisco",
                LastName = "Alves",
                Address = "SP - SP - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}



