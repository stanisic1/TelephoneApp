using System.Collections.Generic;
using System.Linq;
using TelephoneApp.Models;

namespace TelephoneApp.Interfaces
{
    public interface IProducerRepository
    {
        IEnumerable<Producer> GetAll();
        Producer GetById(int id);
        void Delete(Producer producer);
        IEnumerable<Producer> SearchByName (string name);
        IEnumerable<ProducerStatusDTO> SearchStatus();
        IEnumerable<ProducerValueDTO> SearchValue(decimal value);
    }
}
