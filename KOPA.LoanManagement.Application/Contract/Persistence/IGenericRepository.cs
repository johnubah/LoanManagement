using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.Contract.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(long id);
        IReadOnlyList<T> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(long id);

    }
}
