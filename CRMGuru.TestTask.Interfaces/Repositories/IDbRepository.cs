using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.Interfaces.Repositories
{
    
    public interface IDbRepository : IBaseRepositiry
    {
        Task<IQueryable<T>> GetAll<T>(CancellationToken cancel = default) where T : class, IEntity;
       
        Task<T> Add<T>(T item, CancellationToken cancel = default) where T : class, IEntity;
               
        Task<T> Update<T>(T item, CancellationToken cancel = default) where T : class, IEntity;
    }
}
