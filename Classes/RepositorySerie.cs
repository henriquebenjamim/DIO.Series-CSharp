using System;
using System.Collections.Generic;
using DIO.Series.Interfaces; 

namespace DIO.Series
{
    public class RepositorySerie : IRepository<Serie>
    {
        
        private List<Serie> listSerie = new List<Serie>();

        public void Update(int id, Serie objeto)
        {
            listSerie[id] = objeto;
        }

        public void Erase(int id)
        {
            listSerie[id].Erase();
        }

        public void Insert(Serie objeto)
        {
            listSerie.Add(objeto);
        }

        public List<Serie> Listing()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturningById(int id)
        {
            return listSerie[id]; 

        }
    }
}