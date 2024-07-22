
using AppApi.IRepository;
using AppApi.Model;


namespace AppApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            try
            {

                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            try
            {
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();

                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User UpdateUser(User user)
        {
            try
            {
                var userExist = _context.Users.Find(user.Id_User);
                if (userExist != null)
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
