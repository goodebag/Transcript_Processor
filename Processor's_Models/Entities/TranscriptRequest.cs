using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Processor_s_Models.Entities
{
   public  class TranscriptRequest
    {
        [Key]
        public long OrderNumber { get; set; }
    }
}
