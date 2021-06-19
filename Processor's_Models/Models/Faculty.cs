using Processor_s_Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Models
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
