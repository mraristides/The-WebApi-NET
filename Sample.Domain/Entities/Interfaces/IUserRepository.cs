using Sample.Domain.Entities;

namespace Sample.Domain.Entities.Interfaces
{
    public interface IUserRepository
    {
         User ValidateCredentials(User user);
         User ValidateCredentials(string username);
         bool RevokeToken(string username);
         User RefreshUserInfo(User user);
         
    }
}