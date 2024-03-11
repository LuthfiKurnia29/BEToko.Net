using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.common.interfaces;
using AutoMapper;
using domain.entity;
using MediatR;

namespace application.features.auth
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Implement Task For Create User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var key = Guid.NewGuid();
            await _userRepository.CreateUser(user, cancellationToken);
            return _tokenService.GenerateToken(user.IdUser, user.Email, key);
        }
    }
}