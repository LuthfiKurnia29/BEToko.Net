using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.features.auth;
using domain.entity;

namespace application.common.interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user, CancellationToken cancellationToken);
    }
}