//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Liberty_Jadi.EntityModelAccess.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentGrade
    {
    
        public int StudentGradeId { get; set; }
        public string Student_Grade_Name { get; set; }
        public double Score_From { get; set; }
        public double Score_To { get; set; }
        public bool Activated { get; set; }
        public int Grade_Point { get; set; }
    
        public virtual ICollection<CourseRegistration> COURSE_REGISTRATION { get; set; }
        public virtual ICollection<StudentResult> STUDENT_RESULT { get; set; }
        
    }
}
