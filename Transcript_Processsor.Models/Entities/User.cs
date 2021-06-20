using System;
using System.Collections.Generic;
using System.Text;
using static Transcript_Processsor.Models.Entities.EnumsClass;

namespace Transcript_Processsor.Models.Entities
{
   public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string FullName { get { return LastName + " " + FirstName; } }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string  PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
