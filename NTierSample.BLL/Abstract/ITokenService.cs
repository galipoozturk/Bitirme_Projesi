using NTierSample.Model.Entities;

namespace NTierSample.BLL.Abstract
{
    public interface ITokenService
    {
        string BuildToken(User user);
        bool ValidateToken(string token);
    }
}
