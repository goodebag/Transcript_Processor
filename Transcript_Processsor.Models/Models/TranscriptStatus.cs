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
    
    public partial class TranscriptStatus
    {
    
        public int TranscriptStatusId { get; set; }
        public string Transcript_Status_Name { get; set; }
        public string Transcript_Status_Description { get; set; }
    
        public virtual ICollection<TRANSCRIPT_REQUEST> TRANSCRIPT_REQUEST { get; set; }
    }
}