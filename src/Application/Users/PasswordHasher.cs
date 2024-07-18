using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Application.Users;

internal sealed class PasswordHasher(byte[] salt) : IPasswordHasher
{
    public byte[] Hash(string password)
    {
        return KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 256 / 8);
    }

    public bool Verify(string password, byte[] candidate)
    {
        return Hash(password).SequenceEqual(candidate);
    }
}