using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Sample.Domain.Entities;
using Sample.Application.Services;
using Sample.Application.VO;
using Sample.Domain.Entities.Interfaces;
using Sample.Application.Converter.Implementations;

namespace Sample.Application.Core.Services
{
    public class LoginAppService : ILoginAppService
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly UserConverter _converter;
        private readonly ITokenAppService _tokenService;

        public LoginAppService(TokenConfiguration configuration, IUserRepository repository, ITokenAppService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
            _converter = new UserConverter();
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _converter.Parse(userCredentials);
            user = _repository.ValidateCredentials(user);
            if (user == null) return null;
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            if (user.Roles.Count > 0)
            {
                foreach (Role role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Item));
                }
            }

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            
            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }
        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var username = principal.Identity.Name;

            var user = _repository.ValidateCredentials(username);

            if (user == null || 
                user.RefreshToken != refreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now) return null;

            accessToken = _tokenService.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }

        public bool RevokeToken(string username)
        {
            return _repository.RevokeToken(username);
        }
    }
}