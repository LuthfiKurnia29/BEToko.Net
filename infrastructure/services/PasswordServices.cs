using application.common.interfaces;

namespace infrastructure.services;

public class PasswordServices : IPasswordHash
{
    /// <summary>
    /// HashPassword
    /// </summary>
    /// <param name="Password"></param>
    /// <returns></returns>
    public string HashPassword(string Password)
    {
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(Password);
        return hashPassword;
    }

    /// <summary>
    /// ValidatePassword
    /// </summary>
    /// <param name="Password"></param>
    /// <param name="hashPassword"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public bool ValidatePassword(string Password, string hashPassword)
    {
        throw new NotImplementedException();
    }
}