using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Intefaces
{
    public interface IUserServices
    {
        Task<UserDTO> CreateAsync(UserDTO userDTO);
        Task<UserDTO> UpdateAsync(UserDTO userDTO);
        Task Remove(long id);
        Task<ICollection<UserDTO>> GetAllAsync();
        Task<UserDTO> GetAsync(long id);
        Task<UserDTO> GetByEmail(string email);
        Task<ICollection<UserDTO>> SerchByEmail(string email);
        Task<UserDTO> GetByName(string name);
        Task<ICollection<UserDTO>> SerchByName(string name);
    }
}
