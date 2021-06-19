using Processor_s_Data.Interfaces;
using Processor_s_Data.Repo_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoUni_Report.Core.Repo_s
{
    public class RepositoryReadOnly<T> : BaseRepository<T>, IRepositoryReadOnly<T> where T : class
    {
        public RepositoryReadOnly(ProcessorContext
 context) : base(context)
        {
        }
    }
}
