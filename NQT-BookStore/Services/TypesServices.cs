using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class TypesServices : ITypesServicese
    {
        ShoppingDbContext _context;

        public TypesServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateType(Types p)
        {
            try
            {
                _context.Types.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteType(Guid id)
        {
            try
            {
                var p = _context.Types.Find(id);
                _context.Types.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Types> GetAllTypes()
        {
            return _context.Types.ToList();
        }

        public Types GetTypeById(Guid id)
        {
            return _context.Types.FirstOrDefault(p => p.ID == id);
        }

        public List<Types> GetTypesByName(string name)
        {
            return _context.Types.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateType(Types p)
        {
            try
            {
                var a = _context.Types.Find(p.ID);
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Types.Update(a);
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
