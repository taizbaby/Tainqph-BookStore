using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface ICategoryServices
    {
        public bool CreateCategory(Category p);
        public bool UpdateCategory(Category p);
        public bool DeleteCategory(Guid id);
        public List<Category> GetAllCategory();
        public Category GetCategoryById(Guid id);
        public List<Category> GetCategoryByName(string name);
    }
}
