using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Listing();
        T ReturningById(int id);
        void Insert(T entity);
        void Erase(int id);
        void Update(int id, T entity);
        int NextId();

    }
}