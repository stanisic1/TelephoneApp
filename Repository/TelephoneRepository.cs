using Microsoft.EntityFrameworkCore;
using System.Linq;
using TelephoneApp.Interfaces;
using TelephoneApp.Models;

namespace TelephoneApp.Repository
{
    public class TelephoneRepository : ITelephoneRepository
    {
        private readonly AppDbContext _context;

        public TelephoneRepository(AppDbContext context)
        {
            this._context = context;
        }
        public IQueryable<Telephone> GetAll()
        {
            return _context.Telephones.OrderBy(z => z.Model);
        }
        public Telephone GetById(int id)
        {
            return _context.Telephones.Include(z => z.Producer).FirstOrDefault(p => p.Id == id);
        }
       
        public IQueryable<Telephone> GetAllByValue(string value)
        {
            var telephones = _context.Telephones.Include(t => t.Producer).Where(z => z.Model.Contains(value) || z.Producer.Name.Contains(value));
            return telephones.OrderByDescending(z => z.Price);
        }

        public void Add(Telephone telephone)
        {
            _context.Telephones.Add(telephone);
            _context.SaveChanges();
        }

        public void Update(Telephone telephone)
        {
            _context.Entry(telephone).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Telephone telephone)
        {
            _context.Telephones.Remove(telephone);
            _context.SaveChanges();
        }

        public IQueryable<Telephone> Search(decimal min, decimal max)
        {
            return _context.Telephones.Include(z => z.Producer).Where(x => x.Price >= min && x.Price <= max).OrderByDescending(x => x.Price);
        }

    }
}
