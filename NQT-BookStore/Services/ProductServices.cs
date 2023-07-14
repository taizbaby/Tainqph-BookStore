using Microsoft.EntityFrameworkCore;
using NQT_BookStore.IServices;
using NQT_BookStore.Models;

namespace NQT_BookStore.Services
{
    public class ProductServices : IProductServices
    {
        ShoppingDbContext _context;
        public ProductServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                p.ProductCode = Matt();
                _context.Product.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public string Matt()
        {
            if (_context.Product.Count() == 0)
            {
                return "Book1";
            }
            else return "Book1" + _context.Product.Max(c => Convert.ToInt32(c.ProductCode.Substring(4, c.ProductCode.Length - 4)) + 1);
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var p = _context.Product.Find(id);
                _context.Product.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> lst = new List<Product>();

            return _context.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _context.Product.FirstOrDefault(p => p.ID == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return _context.Product.Where(c => c.Name.Contains(name)).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var a = _context.Product.Find(p.ID);
                a.Types = p.Types;
                a.Producer = p.Producer;
                a.ProductCode = p.ProductCode;
                a.Name = p.Name;
                a.Images = p.Images;
                a.SupplierID = p.SupplierID;
                a.CategoryID = p.CategoryID;
                a.ProductCode = p.ProductCode;
                a.Describe = p.Describe;
                a.Quantity = p.Quantity;
                a.Price = p.Price;
                a.Status = p.Status;
                _context.Product.Update(a);
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
