using System;
using System.Collections.Generic;
using System.Text;

namespace Transcript_Processsor.Models.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public byte UnitLoad { get; set; }
        public int DeptId { get; set; }
        public virtual Department Dept { get; set; }

    }
}
