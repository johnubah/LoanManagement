using KOPA.LoanManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LoanManagementDbContext _loanManagementDbContext;
        public GenericRepository(LoanManagementDbContext loanManagementDbContext)
        {
            this._loanManagementDbContext = loanManagementDbContext;
        }
        public async Task<T> Add(T entity)
        {
            await this._loanManagementDbContext.AddAsync(entity);
            await this._loanManagementDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            this._loanManagementDbContext.Set<T>().Remove(entity);
           await this._loanManagementDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(long id)
        {
            T entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(long id)
        {
            return await _loanManagementDbContext.Set<T>().FindAsync(id);
                
        }

        public IReadOnlyList<T> GetAll()
        {
            return _loanManagementDbContext.Set<T>().ToList();
        }

        public async Task Update(T entity)
        {
            _loanManagementDbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._loanManagementDbContext.SaveChangesAsync();


        }
    }
}
