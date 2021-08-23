using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.Application.VO
{
    public class UserVO
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public string RefreshToken {get; set; }
        public DateTime RefreshTokenExpiryTime {get; set; }
        public List<RoleVO> Roles { get; set; }
    }
}