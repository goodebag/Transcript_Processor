﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Department> Departments { get; set; }

    }
}
