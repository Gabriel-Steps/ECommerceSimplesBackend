using ECommerceSimplesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimplesBackend.Infra.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ECommerceDbContext _context;

        public UserRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
    }
}
