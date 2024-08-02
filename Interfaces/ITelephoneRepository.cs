using System.Linq;
using TelephoneApp.Models;

namespace TelephoneApp.Interfaces
{
    public interface ITelephoneRepository
    {
        IQueryable<Telephone> GetAll();
        Telephone GetById(int id);
        IQueryable<Telephone> GetAllByValue(string value);
        void Add(Telephone telephone);
        void Update(Telephone telephone);
        void Delete(Telephone telephone);
        IQueryable<Telephone> Search(decimal min, decimal max);
    }
}
