using System.Security.Cryptography;
using UniRoute.Domain.Interfaces.Services;

namespace UniRoute.Application.Services;

public class CryptographyService : ICryptographyService
{
    public string Encrypth(string value, out long salt)
    {
        salt = GenerateSalt();

        var saltBytes = BitConverter.GetBytes(salt);

        var hash = GenerateHash(value, saltBytes);

        return Convert.ToBase64String(hash);
    }

    public bool VerifyPassword(string encriptedValue, string valueToCompare, long salt)
    {
        var saltBytes = BitConverter.GetBytes(salt);

        var encriptedValueBytes = Convert.FromBase64String(encriptedValue);

        var valueToCompareHashBytes = GenerateHash(valueToCompare, saltBytes);

        return CryptographicOperations.FixedTimeEquals(encriptedValueBytes, valueToCompareHashBytes);
    }

    private byte[] GenerateHash(string value, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            value,
            salt,
            100_000,
            HashAlgorithmName.SHA256
        );

        return pbkdf2.GetBytes(32);
    }
    private long GenerateSalt()
    {
        Span<byte> buffer = stackalloc byte[8];
        RandomNumberGenerator.Fill(buffer);
        return BitConverter.ToInt64(buffer);
    }
}
