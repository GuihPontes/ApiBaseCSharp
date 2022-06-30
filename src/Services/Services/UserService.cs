using AutoMapper;
using Base.Domain.Entities;
using Core.Exceptions;
using Infra.Interfaces;
using Services.DTO;
using Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }





        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {
            var userExists = await repository.GetByEmail(userDTO.Email);
            if (userExists != null)
                throw new DomainExceptions("Ja existe um usuário cadastrado com o email informado");

            var user = mapper.Map<User>(userDTO);
            user.Validate();

            var userCreate = await repository.CreateAsync(user);
            return mapper.Map<UserDTO>(userCreate);

        }

        public async Task<UserDTO> UpdateAsync(UserDTO userDTO)
        {
            var userExists = await repository.GetAsync(userDTO.Id);

            if (userExists == null)
                throw new DomainExceptions("Não existe nenhum usuário com o Id informado!");

            var user = mapper.Map<User>(userDTO);
            user.Validate();

            var userUp = await repository.UpdateAsync(user);

            return mapper.Map<UserDTO>(userUp);


        }

        public async Task Remove(long id)
        {
            await repository.Remove(id);
        }

        public async Task<UserDTO> GetAsync(long id)
        {
            var user = await repository.GetAsync(id);
            return mapper.Map <UserDTO>(user);
        }

        public async Task<ICollection<UserDTO>> GetAllAsync()
        {
            var all = await repository.GetAllAsync();
            return mapper.Map<ICollection<UserDTO>>(all);
        }

        

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await repository.GetByEmail(email);
            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByName(string name)
        {
            var user = await repository.GetByName(name);
            return mapper.Map<UserDTO>(user);
        }

        

        public async Task<ICollection<UserDTO>> SerchByEmail(string email)
        {
            var all = await repository.SerchByEmail(email);
            return mapper.Map<ICollection<UserDTO>>(all);
        }

        public async Task<ICollection<UserDTO>> SerchByName(string name)
        {
            var all = await repository.SerchByName(name);
            return mapper.Map<ICollection<UserDTO>>(all);
        }

       
        
    }
}
