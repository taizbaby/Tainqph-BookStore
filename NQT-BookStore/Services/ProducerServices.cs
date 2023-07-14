using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class ProducerServices : IProducerServices
    {
        ShoppingDbContext _context;
        public ProducerServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateProducer(Producer p)
        {
            try
            {
                _context.Producers.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProducer(Guid id)
        {
            try
            {
                var p = _context.Producers.Find(id);
                _context.Producers.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Producer> GetAllProducer()
        {
            return _context.Producers.ToList();
        }

        public Producer GetProducerById(Guid id)
        {
            return _context.Producers.FirstOrDefault(p => p.ID == id);
        }

        public List<Producer> GetProducerByName(string name)
        {
            return _context.Producers.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateProducer(Producer p)
        {
            try
            {
                var a = _context.Producers.Find(p.ID);
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Producers.Update(a);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
