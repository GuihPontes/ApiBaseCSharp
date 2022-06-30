using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base.Domain.Entities.Base
    {
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task Remove(long id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(long id);
    }
}
