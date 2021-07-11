using CRMGuru.TestTask.DAL.Context;
using CRMGuru.TestTask.DAL.Entities;
using CRMGuru.TestTask.Interfaces.Entities;
using CRMGuru.TestTask.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.DAL.Repositories
{
    public class EFRepositoty : IDbRepository
    {
        private readonly EFContext _db;
       
        public EFRepositoty(EFContext db)
        {
            _db = db;          
        }

        public async Task<T> Add<T>(T item, CancellationToken cancel = default) where T : class, IEntity
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            await _db.Set<T>().AddAsync(item, cancel).ConfigureAwait(false);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;

        }

        public async Task<T> Get<T>(string name, CancellationToken cancel = default) where T : class, IEntity
        {
            return await _db.Set<T>().FirstOrDefaultAsync(x => x.Name == name, cancel).ConfigureAwait(false);
        }

        public async Task<IQueryable<T>> GetAll<T>(CancellationToken cancel = default) where T : class, IEntity
        {
            
            var result = await Task.Run(() => _db.Set<T>(), cancel).ConfigureAwait(false);
            return result;
        }

        public async Task<T> Update<T>(T item, CancellationToken cancel) where T : class, IEntity
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _db.Update(item);
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }  
    }
}
