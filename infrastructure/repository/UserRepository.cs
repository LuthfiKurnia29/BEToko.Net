using application.common.interfaces;
using application.features.auth;
using domain.entity;
using infrastructure.persistence;

namespace infrastructure.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDbContext _context;
        private readonly IPasswordHash _passwordHash;
        public UserRepository(IAppDbContext context, IPasswordHash passwordHash)
        {
            _context = context;
            _passwordHash = passwordHash;
        }
        /// <summary>
        /// CreateUser(Register)
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreateUser(User user, CancellationToken cancellationToken)
        {
            if (user.Password != null)
            {
                user.Password =  _passwordHash.HashPassword(user.Password);
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}