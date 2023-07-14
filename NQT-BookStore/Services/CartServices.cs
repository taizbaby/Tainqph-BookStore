using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class CartServices : ICartServices
    {
        ShoppingDbContext _context;

        public CartServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                _context.Carts.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var p = _context.Carts.Find(id);
                _context.Carts.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Cart> GetAllCart()
        {
            return _context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return _context.Carts.FirstOrDefault(p => p.ID == id);
        }

        public List<Cart> GetCartByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart p)
        {
            try
            {
                var a = _context.Carts.Find(p.ID);
                a.Describe = p.Describe;
                _context.Carts.Update(a);
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
