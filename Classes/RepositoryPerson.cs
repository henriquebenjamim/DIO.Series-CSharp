using System;
using System.Collections.Generic;
using DIO.Series.Interfaces; 

namespace DIO.Series
{
    public class RepositoryPerson : IRepository<Person>
    {
        
        private List<Person> listPerson = new List<Person>();

        public void Update(int id, Person objeto)
        {
            listPerson[id] = objeto;
        }

        public void Erase(int id)
        {
            listPerson[id].Erase();
        }

        public void Insert(Person objeto)
        {
            listPerson.Add(objeto);
        }

        public List<Person> Listing()
        {
            return listPerson;
        }

        public int NextId()
        {
            return listPerson.Count;
        }

        public Person ReturningById(int id)
        {
            return listPerson[id]; 

        }
    }
}