using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
