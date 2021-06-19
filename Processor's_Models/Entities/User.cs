using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Entities
{
   public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string FullName { get { return LastName + " " + FirstName; } }

    }
}
