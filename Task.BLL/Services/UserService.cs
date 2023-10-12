using Task.BLL.DTO;
using Task.BLL.Interfaces;
using Task.DAL.Entities;
using Task.DAL.Interfaces;

namespace Task.BLL.Services;
    
public class UserService : IEntityService<UsersDto>
    {
        private readonly IRepository<Users> _userRepository;

        public UserService(IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UsersDto> GetAll()
        {
            var users = _userRepository.GetAll()
                .Select(user => new UsersDto
                {
                    Id = user.Id,
                    Surname = user.Surname,
                    Name = user.Name,
                    Middlename = user.Middlename,
                    Birthday = user.Birthday
                })
                .ToList();

            return users;
        }

        public UsersDto GetById(int id)
        {
            var user = _userRepository.Get(id);

            var userDto = new UsersDto
            {
                Id = user.Id,
                Surname = user.Surname,
                Name = user.Name,
                Middlename = user.Middlename,
                Birthday = user.Birthday
            };

            return userDto;
        }

        public void Create(UsersDto userDto)
        {
            var user = new Users
            {
                Surname = userDto.Surname,
                Name = userDto.Name,
                Middlename = userDto.Middlename,
                Birthday = userDto.Birthday
            };

            _userRepository.Create(user);
        }

        public void Update(UsersDto userDto)
        {
            var user = _userRepository.Get(userDto.Id);

            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.Surname = userDto.Surname;
            user.Name = userDto.Name;
            user.Middlename = userDto.Middlename;
            user.Birthday = userDto.Birthday;

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            var user = _userRepository.Get(id);

            _userRepository.Delete(id);
        }
    }
