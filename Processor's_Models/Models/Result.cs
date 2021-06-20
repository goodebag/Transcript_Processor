using Processor_s_Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Models.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public byte UnitLoad { get; set; }
        public char Grade { get; set; }
        public byte GradePoints { get; set; }

        public int TranscriptRequestId { get; set; }
        public virtual TranscriptRequest TranscriptRequest { get; set; }
    }
}
