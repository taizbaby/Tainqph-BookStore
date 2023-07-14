using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface IRoleServices
    {
        public bool CreateRole(Role p);
        public bool DeleteRole(Guid id);
        public bool UpdateRole(Role p);
        public List<Role> GetAllRoles();
        public List<Role> GetRoleByName(string name);
        public Role GetRoleById(Guid id);
    }
}
