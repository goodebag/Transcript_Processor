using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Processor_s_Data.Repo_s
{
    public partial class ProcessorContext : DbContext
    {
        public ProcessorContext()
        {

        }
        public ProcessorContext(DbContextOptions<ProcessorContext>options):base(options)
        {
        }
        public virtual DbSet<TranscriptRequest> MyProperty { get; set; }
    }
}
