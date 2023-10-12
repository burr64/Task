using Task.DAL.Data;
using Task.DAL.Entities;
using Task.DAL.Interfaces;

namespace Task.DAL.Repositories
{
    public class UserRepository : IRepository<Users>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        public Users Get(int id)
        {
            return _context.Users.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Users> Find(Func<Users, bool> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public void Create(Users users)
        {
            _context.Add(users);
            _context.SaveChanges();
        }

        public void Update(Users users)
        {
            _context.Update(users);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var users = _context.Users.Find(id);
            if (users != null)
            {
                _context.Users.Remove(users);
                _context.SaveChanges();
            }
        }
    }
}