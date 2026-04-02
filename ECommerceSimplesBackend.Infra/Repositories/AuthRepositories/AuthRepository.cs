using ECommerceSimplesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSimplesBackend.Infra.Repositories.AuthRepositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ECommerceDbContext _context;

        public AuthRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<User?> LoginUser(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
        }

        public async Task Register(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
