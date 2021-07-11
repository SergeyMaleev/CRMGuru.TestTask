using CRMGuru.TestTask.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.Interfaces.Repositories.Base
{
    public interface IBaseRepositiry
    {
        Task<T> Get<T>(string name, CancellationToken cancel = default) where T : class, IEntity;
    }
}
