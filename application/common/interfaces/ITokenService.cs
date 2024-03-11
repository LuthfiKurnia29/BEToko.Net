namespace application.common.interfaces;

public interface ITokenService
{
    string GenerateToken(Guid idUser, string email, Guid key);
}