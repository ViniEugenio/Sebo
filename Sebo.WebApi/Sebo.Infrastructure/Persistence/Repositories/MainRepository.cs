using Microsoft.EntityFrameworkCore;
using Sebo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sebo.Infrastructure.Persistence.Repositories
{
    public abstract class MainRepository<T> : IMainRepository<T> where T : class
    {

        public readonly SeboDbContext Context;
        public readonly DbSet<T> DbSet;

        public MainRepository(SeboDbContext Context)
        {
            this.Context = Context;
            DbSet = Context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllWithExpression(Expression<Func<T, bool>> Expression)
        {
            return await DbSet.Where(Expression).ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<T> GetWithExpression(Expression<Func<T, bool>> Expression)
        {
            return await DbSet.FirstOrDefaultAsync(Expression);
        }

        public async Task Add(T Entity)
        {
            DbSet.Add(Entity);
            await SaveChanges();
        }

        public async Task Update(T Entity)
        {
            DbSet.Update(Entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

    }
}
