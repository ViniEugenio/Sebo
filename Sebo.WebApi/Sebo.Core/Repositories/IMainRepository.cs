using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sebo.Core.Repositories
{
    public interface IMainRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllWithExpression(Expression<Func<T, bool>> Expression);
        Task<T> GetById(Guid Id);
        Task<T> GetWithExpression(Expression<Func<T, bool>> Expression);
        Task Add(T Entity);
        Task Update(T Entity);
        Task SaveChanges();
    }
}
