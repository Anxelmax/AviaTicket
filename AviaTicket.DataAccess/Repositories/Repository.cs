using AviaTicket.DataAccess.Contexts;
using AviaTicket.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AviaTicket.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext context;
    private readonly DbSet<T> set;
    public Repository(AppDbContext context)
    {
        this.context = context;
        this.set = context.Set<T>();
    }
    public async Task<bool> DeleteAsync(T entity)
    {
        await Task.FromResult(context.Remove(entity));
        return true;
    }

    public async Task<T> InsertAsync(T entity)
    {
        return await Task.FromResult(set.Add(entity).Entity);
    }

    public async Task SaveChangesAsync()
    {
        await Task.FromResult(context.SaveChanges());
    }

    public async Task<IEnumerable<T>> SelectAllAsync(Expression<Func<T, bool>> expression = null, string[] includes = null)
    {
        var query = expression is not null ? set.Where(expression) : set;
        if (includes is not null)
            foreach(var include in includes)
                query.Include(include);

        return await Task.FromResult(query.AsEnumerable());
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        var query = expression is not null ? set.Where(expression) : set;

        if (includes is not null)
            foreach (var include in includes)
                query.Include(include);

        return await Task.FromResult(query.FirstOrDefault());
    }

    public async Task<T> UpdateAsync(T entity)
    {
        return await Task.FromResult(set.Update(entity).Entity);
    }
}
