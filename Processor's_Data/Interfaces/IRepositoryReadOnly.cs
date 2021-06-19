using System;
using System.Collections.Generic;
using System.Text;

namespace Processor_s_Data.Interfaces
{
   public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : class
    {
    }
}
