using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.Interfaces.Repositories
{    
    public interface IWebRepository : IBaseRepositiry
    {       
        Task<IEnumerable<T>> GetArray<T>(string name, CancellationToken cancel = default) where T : class;
    }
}
