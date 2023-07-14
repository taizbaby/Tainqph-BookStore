using NQT_BookStore.Models;

namespace NQT_BookStore.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User p);
        public bool UpdateUser(User p);
        public bool DeleteUser(Guid id);

        public List<User> GetAllUser();
        public List<User> GetUserByName(string name);
        public User GetUserById(Guid id);
    }
}
