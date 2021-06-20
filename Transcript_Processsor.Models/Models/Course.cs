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
<<<<<<< HEAD:Transcript_Processsor.Models/Models/Course.cs
        public short UnitLoad { get; set; }
=======
        public byte UnitLoad { get; set; }

>>>>>>> f542b10ba58514ed430e3a0bc2d99eb2e46f9bd5:Processor's_Models/Models/Course.cs
        public int DeptId { get; set; }
        public virtual Department Dept { get; set; }

    }
}
