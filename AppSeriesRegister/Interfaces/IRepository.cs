using System;
using System.Collections.Generic;
using System.Text;

namespace AppSeriesRegister.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetList();

        T ReturnById(int id);
        void Insert(T _object);
        void Delete(int id);
        void Update(int id, T _object);
        int NextId();

    }
}
