namespace UniRoute.Domain.Interfaces.Services;

public interface ICryptographyService
{
    string Encrypth(string value, out long salt);

    bool VerifyPassword(string encriptedValue, string valueToCompare, long salt);
}
