using System;
using System.Collections.Generic;
using System.Text;

namespace Transcript_Processsor.Models.Entities
{
    public class EnumsClass
    {
        public enum Role
        {
            Student=1,
            Staff,
            Admin,
            SuperAdmin
        }
        public enum Status
        {
            Submitted = 1,
            Assigined,
            Processing,
            ReadyForDispatch,
            Dispatched,
            Completed
        }
    }
}
