using Application.Queries;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class GetUsersQueryHandler : IGetUsersQueryHandler
    {
        private readonly AppDbContext _dbContext;

        public GetUsersQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserResponse>?> Handle()
        {
            return await _dbContext.Users.AsNoTracking().Select(u => new UserResponse()
            {
                Name = u.Name,
                Id = u.Id,
                Email = u.Email,
            }).ToListAsync();
        }
    }
}
