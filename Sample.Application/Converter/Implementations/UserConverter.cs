using System.Collections.Generic;
using System.Linq;
using Sample.Application.Converter.Contract;
using Sample.Application.VO;
using Sample.Domain.Entities;

namespace Sample.Application.Converter.Implementations
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return null;
            return new User
            {
                UserName = origin.UserName,
                Password = origin.Password,
                RefreshToken = origin.RefreshToken,
                RefreshTokenExpiryTime = origin.RefreshTokenExpiryTime
            };
        }

        public List<User> Parse(List<UserVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public UserVO Parse(User origin)
        {
            if (origin == null) return null;
            return new UserVO
            {
                UserName = origin.UserName,
                Password = origin.Password,
                RefreshToken = origin.RefreshToken,
                RefreshTokenExpiryTime = origin.RefreshTokenExpiryTime
            };
        }

        public List<UserVO> Parse(List<User> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}