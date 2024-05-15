using AviaTicket.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AviaTicket.DataAccess.Repositories;

public interface IRepository<T> where T : Auditable
{
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T> SelectAsync(
        Expression<Func<T, bool>> expression,
        string[] includes = null);
    Task<IEnumerable<T>> SelectAllAsync(
        Expression<Func<T, bool>> expression = null, 
        string[] includes = null);
    Task SaveChangesAsync();
}
