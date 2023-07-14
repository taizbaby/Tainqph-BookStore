using Microsoft.EntityFrameworkCore;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class CartDetailsServices : ICartDetailsServices
    {
        ShoppingDbContext _context;

        public CartDetailsServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateCartDetails(CartDetails p)
        {
            try
            {
                _context.CartDetails.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCartDetails(Guid id)
        {
            try
            {
                var p = _context.CartDetails.Find(id);
                _context.CartDetails.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<CartDetails> GetAllCartDetails()
        {
            return _context.CartDetails.Include(cd => cd.Product).ThenInclude(p => p.Types)
              .Include(cd => cd.Product).ThenInclude(p => p.Category)
              .Include(cd => cd.Product).ThenInclude(p => p.Producer)
              .Include(cd => cd.Product).ThenInclude(p => p.Supplier)
              .Include(cd => cd.Product).ThenInclude(p => p.Images)
              .ToList();
        }

        public CartDetails GetCartDetailsById(Guid id)
        {
            return _context.CartDetails.FirstOrDefault(p => p.ID == id);
        }

        public List<CartDetails> GetCartDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCartDetails(CartDetails p)
        {
            try
            {
                var a = _context.CartDetails.Find(p.ID);
                a.UserID = p.UserID;
                a.ProductId = p.ProductId;
                a.Quantity = p.Quantity;
                a.Status = p.Status;
                _context.CartDetails.Update(a);
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
