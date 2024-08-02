using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TelephoneApp.Interfaces;
using TelephoneApp.Models;

namespace TelephoneApp.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext _context;

        public ProducerRepository(AppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Producer> GetAll()
        {
            return _context.Producers.OrderBy(z => z.Name);
        }
        public Producer GetById(int id)
        {
            return _context.Producers.FirstOrDefault(z => z.Id == id);
        }

        public void Delete(Producer producer)
        {
            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }

        public IEnumerable<Producer> SearchByName(string name)
        {
            return _context.Producers.Where(p => p.Name.Equals(name)).OrderBy(p => p.CountryOrigin).ThenByDescending(p => p.Name);
        }

        
        public IEnumerable<ProducerStatusDTO> SearchStatus()
        {
            return _context.Telephones.GroupBy(p => p.ProducerId)
                .Select(c => new ProducerStatusDTO
                {
                    Id = c.Key,
                    Name = _context.Producers.Where(z => z.Id == c.Key).Select(z => z.Name).Single(),
                    NumberOfModels = c.Distinct().Count(),
                    EntireAvailableAmount = _context.Telephones.Where(p => p.ProducerId == c.Key).Select(c => c.AvailableAmount).Sum()
                }).OrderByDescending(p => p.EntireAvailableAmount);
        }

        public IEnumerable<ProducerValueDTO> SearchValue(decimal value)
        {
            return _context.Telephones.Include("Producer").GroupBy(p => p.ProducerId)
                .Select(c => new ProducerValueDTO
                {
                    Name = _context.Producers.Where(z => z.Id == c.Key).Select(z => z.Name).Single(),
                    LowestPrice = _context.Telephones.Where(z => z.ProducerId == c.Key).Select(z => z.Price).Min(),
                   // LowestPrice = c.Min(p => p.Price),
                    AveragePrice = c.Average(p => p.Price)
                }).Where(p => p.AveragePrice < value).OrderBy(p => p.Name);
        }
    }
}
