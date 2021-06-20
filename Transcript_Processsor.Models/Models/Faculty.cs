using Transcript_Processsor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transcript_Processsor.Models.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
