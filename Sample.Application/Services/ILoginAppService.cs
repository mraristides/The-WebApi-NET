using Sample.Application.VO;

namespace Sample.Application.Services
{
    public interface ILoginAppService
    {
         TokenVO ValidateCredentials(UserVO user);
         TokenVO ValidateCredentials(TokenVO user);
         bool RevokeToken(string username);

    }
}