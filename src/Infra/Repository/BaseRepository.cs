using Base.Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base.Domain.Entities.Base
    {
        private readonly SqlContext context;

        public BaseRepository(SqlContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>()
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public virtual async Task<T> GetAsync(long id)
        {
            var obj = await context.Set<T>()
                                           .AsNoTracking()
                                           .Where(x => x.Id == id)
                                           .ToListAsync();

            return obj.FirstOrDefault();
                
        }

        public virtual async Task Remove(long id)
        {
            var obj = await GetAsync(id);
            if(obj !=null)
            {
                context.Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
