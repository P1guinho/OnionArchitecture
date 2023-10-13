using Domain.Entities;
using Domain.IUserRepository;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> CreateAsync(string name, string email)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                CreatedOnUtc = DateTime.UtcNow,
                Email = email,
                Name = name,
            };

            return await _userRepository.InsertAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            if (user is null)
                throw new ApplicationException("Invalid Data");

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null)
                throw new ApplicationException("user not found");

            await _userRepository.DeleteAsync(user);
        }

    }
}
