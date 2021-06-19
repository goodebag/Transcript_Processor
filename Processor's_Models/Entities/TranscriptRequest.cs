using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Processor_s_Models.Entities.EnumsClass;

namespace Processor_s_Models.Entities
{
   public  class TranscriptRequest
    {
        [Key]
        public long OrderNumber { get; set; }
        public long StudentId { get; set; }
        public virtual User Student { get; set; }
        public string MatricNumber { get; set; }
        public DateTime OrderStartDate { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public long HandlerId { get; set; }
        public Status Status { get; set; }

    }
}
