using System;
using System.Collections.Generic;
using System.Text;
using static Processor_s_Models.Entities.EnumsClass;

namespace Processor_s_Models.Entities
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
    }
}
