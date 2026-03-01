using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Reposetories.Contract;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcotext;

        public GenericRepository(StoreContext dbcotext)
        {
            this._dbcotext = dbcotext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbcotext.Set<T>().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbcotext.Set<T>().FindAsync(id);
        }

    }
}
