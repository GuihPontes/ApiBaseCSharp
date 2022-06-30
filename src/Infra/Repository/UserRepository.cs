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
    public class UserRepository : BaseRepository<User>,IUserRepository
    {
        private readonly SqlContext _context;
        public UserRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

       
        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                           .Where
                                           (
                                                x =>
                                                    x.Email.ToLower() == email.ToLower()
                                            )
                                           .AsNoTracking()
                                           .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<User> GetByName(string name)
        {
            var user = await _context.Users
                                           .Where
                                           (
                                                x =>
                                                    x.Name.ToLower() == name.ToLower()
                                            )
                                           .AsNoTracking()
                                           .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<ICollection<User>> SerchByEmail(string email)
        {
            var userAll = await _context.Users
                                                .Where
                                                 (
                                                        x =>
                                                            x.Email.ToLower().Contains(email.ToLower())
                                                  )
                                                 .AsNoTracking()
                                                 .ToListAsync();
            return userAll;
        }

        public async Task<ICollection<User>> SerchByName(string name)
        {
            var userAll = await _context.Users
                                               .Where
                                                (
                                                       x =>
                                                           x.Name.ToLower().Contains(name.ToLower())
                                                 )
                                                .AsNoTracking()
                                                .ToListAsync();
            return userAll;
        }
    }
}
