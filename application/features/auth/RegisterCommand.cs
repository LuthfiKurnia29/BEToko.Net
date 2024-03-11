using domain.entity;
using MediatR;

namespace application.features.auth
{
    public class RegisterCommand : IRequest<string>
    {
        public string Nama { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }  
    }
}