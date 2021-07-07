using System;
using System.Collections.Generic;
using System.Text;

namespace Transcript_Processsor.Models.Models
{
  public  class UserResponse
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }


        public UserResponse(UserModel user, string token, string Role)
        {
            Fullname = user.Fullname;
            Username = user.Username;
            Token = token;
            this.Role = Role;
        }
    }
}
