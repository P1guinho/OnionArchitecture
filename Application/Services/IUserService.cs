using Domain.Entities;

namespace Application.Services
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(string name, string email);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(Guid id);
    }
}
