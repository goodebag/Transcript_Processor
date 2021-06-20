using System;
using System.Collections.Generic;
using System.Text;

namespace Transcript_Processor_Data.Interfaces
{
   public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {
    }
}
