using Application.Queries;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public class GetUserByIdQueryHandler : IGetUserByIdQueryHandler
    {
        private readonly AppDbContext _dbContext;

        public GetUserByIdQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserResponse?> Handle(Guid id)
        {
            return await _dbContext.Users.AsNoTracking()
                .Where(u => u.Id == id)
                .Select(user => new UserResponse()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                })
                .FirstOrDefaultAsync();
        }
    }
}
