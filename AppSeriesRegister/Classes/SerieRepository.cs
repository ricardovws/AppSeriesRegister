using AppSeriesRegister.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSeriesRegister.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Delete(int id)
        {
            serieList[id].DeleteIt();
        }

        public List<Serie> GetList()
        {
            return serieList;
        }

        public void Insert(Serie _object)
        {
            serieList.Add(_object);
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public Serie ReturnById(int id)
        {
            return serieList[id];
        }

        public void Update(int id, Serie _object)
        {
            serieList[id] = _object;
        }
    }
}
