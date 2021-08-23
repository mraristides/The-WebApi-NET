using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Sample.Domain.Entities;
using Sample.Domain.Context;
using Sample.Domain.Entities.Interfaces;

namespace Sample.Repository.Generic
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;
        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(User user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            var validate = _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
            if (validate == null) return null;

            var roles = (
                from uh in _context.UserRoles where uh.User_Id.Equals(validate.Id)
                join r in _context.Roles on uh.Role_Id equals r.Id into uhr
                from r in uhr.DefaultIfEmpty()
                select new Role { Id = r.Id, Item = r.Item, Description = r.Description, Enabled = r.Enabled }
            ).ToList();
            validate.Roles = roles;

            return validate;
        }
        public User ValidateCredentials(string username)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == username));
        }

        public bool RevokeToken(string username)
        {
            var user = _context.Users.SingleOrDefault(u => (u.UserName == username));
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(p => p.Id.Equals(user.Id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        
    }
}