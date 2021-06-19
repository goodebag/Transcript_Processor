using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public short UnitLoad { get; set; }
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
