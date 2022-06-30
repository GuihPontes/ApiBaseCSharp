using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<ICollection<User>> SerchByEmail(string email);
        Task<User> GetByName(string name);
        Task<ICollection<User>> SerchByName(string name);

    }
}
