using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface ICartDetailsServices
    {
        public bool CreateCartDetails(CartDetails p);
        public bool UpdateCartDetails(CartDetails p);
        public bool DeleteCartDetails(Guid id);
        public List<CartDetails> GetAllCartDetails();
        public CartDetails GetCartDetailsById(Guid id);
        public List<CartDetails> GetCartDetailsByName(string name);
    }
}
