using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface ICartServices
    {
        public bool CreateCart(Cart p);
        public bool UpdateCart(Cart p);
        public bool DeleteCart(Guid id);
        public List<Cart> GetAllCart();
        public List<Cart> GetCartByName(string name);
        public Cart GetCartById(Guid id);
    }
}
