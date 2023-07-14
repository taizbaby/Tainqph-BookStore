using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface ISupplierServices
    {
        public bool CreateSupplier(Supplier p);
        public bool DeleteSupplier(Guid id);
        public bool UpdateSupplier(Supplier p);

        public List<Supplier> GetAllSupplier();
        public Supplier GetSupplierById(Guid id);
        public List<Supplier> GetSupplierByName(string name);
    }
}
