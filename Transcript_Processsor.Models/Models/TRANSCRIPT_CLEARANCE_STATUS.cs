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
    
    public partial class TRANSCRIPT_CLEARANCE_STATUS
    {
        public TRANSCRIPT_CLEARANCE_STATUS()
        {
            this.TRANSCRIPT_REQUEST = new HashSet<TRANSCRIPT_REQUEST>();
        }
    
        public int Transcript_clearance_Status_Id { get; set; }
        public string Transcript_clearance_Status_Name { get; set; }
        public string Transcript_clearance_Status_Description { get; set; }
    
        public virtual ICollection<TRANSCRIPT_REQUEST> TRANSCRIPT_REQUEST { get; set; }
    }
}
