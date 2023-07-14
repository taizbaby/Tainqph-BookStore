using NQT_BookStore.Models;

namespace NQT_BookStore.ViewModel
{
    public class ProductCategoryModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
