namespace application.common.interfaces;

public interface IPasswordHash
{
    string HashPassword(string Password);
    bool ValidatePassword(string Password, string hashPassword);
}