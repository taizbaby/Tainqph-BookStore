using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface ITypesServicese
    {
        public bool CreateType(Types p);
        public bool DeleteType(Guid id);
        public bool UpdateType(Types p);
        public List<Types> GetAllTypes();
        public Types GetTypeById(Guid id);
        public List<Types> GetTypesByName(string name);
    }
}
