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
    using Transcript_Processsor.Models.Entities;
    using Transcript_Processsor.Models.Models;

    public partial class CourseRegistration
    {
    
        public long CourseRegistrationId { get; set; }
        public long Student_Id { get; set; }
        public int Level_Id { get; set; }
        public int Programme_Id { get; set; }
        public int Department_Id { get; set; }
        public int Session_Id { get; set; }
        public int Semester_Id { get; set; }
        public Nullable<System.DateTime> Date_Registered { get; set; }
        public long Course_Id { get; set; }
        public Nullable<double> Test_Score { get; set; }
        public Nullable<double> Exam_Score { get; set; }
        public Nullable<double> Total_Score { get; set; }
        public Nullable<long> Uploader_Id { get; set; }
        public Nullable<System.DateTime> Date_Uploaded { get; set; }
        public Nullable<int> Student_Grade_Id { get; set; }
        public Nullable<bool> Is_Absent { get; set; }
        public string Absent_Reason { get; set; }
    
        public virtual Course COURSE { get; set; }
        public virtual Department DEPARTMENT { get; set; }
        public virtual Person STUDENT { get; set; }
        public virtual StudentGrade STUDENT_GRADE { get; set; }
        public virtual User USER { get; set; }
        public virtual ICollection<StudentResult> STUDENT_RESULT { get; set; }
    }
}
