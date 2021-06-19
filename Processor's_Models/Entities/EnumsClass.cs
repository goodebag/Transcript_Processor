using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Entities
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
