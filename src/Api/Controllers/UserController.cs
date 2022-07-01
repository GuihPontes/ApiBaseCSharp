using Api.Util;
using Api.ViewModel;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices services;
        private IMapper mapper;

        public UserController(IUserServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }


        [HttpPost]
        [Authorize]
        [Route("/api/v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userCreate)
        {
            try
            {
                var userDTO = mapper.Map<UserDTO>(userCreate);

                var create = await services.CreateAsync(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Data = userCreate
                });
            }
            catch (DomainExceptions ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }


        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/users/update")]

        public async Task<IActionResult> Update([FromBody] UpdateViewModel update)
        {
            try
            {

                var userDTO = mapper.Map<UserDTO>(update);

                var userUpdate = await services.UpdateAsync(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso ! ",
                    Success = true,
                    Data = userDTO
                });
            }
            catch (DomainExceptions ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }

            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await services.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário excluido com sucesso ! ",
                    Success = true,
                    Data = null
                });

            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }

            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await services.GetAsync(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário encontrado",
                        Success = true,
                        Data = user
                    });
                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> GetAsync()
        {
            var allUsers = await services.GetAllAsync();


            return Ok(new ResultViewModel
            {
                Message = "Usuários encontrados com sucesso!",
                Success = true,
                Data = allUsers
            });

        }
        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-nome")]
        public async Task<IActionResult> GetByNomeAsync([FromQuery] string nome)
        {
            var user = await services.GetByName(nome);



            if (user == null)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado com o nome informado.",
                    Success = true,
                    Data = user
                });

            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso!",
                Success = true,
                Data = user
            });
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmailAsync([FromQuery] string email)
        {
            var user = await services.GetByEmail(email);

            

            if (user == null)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado com o email informado.",
                    Success = true,
                    Data = user
                });

            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso!",
                Success = true,
                Data = user
            });
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByNameAsync([FromQuery] string name)
        {
            var allUsers = await services.SerchByName(name);

          

            if (allUsers == null )
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado com o nome informado",
                    Success = true,
                    Data = null
                });

            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso!",
                Success = true,
                Data = allUsers
            });
        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmailAsync([FromQuery] string email)
        {
            var allUsers = await services.SerchByEmail(email);

            

            if (allUsers == null)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum usuário foi encontrado com o email informado",
                    Success = true,
                    Data = null
                });

            return Ok(new ResultViewModel
            {
                Message = "Usuário encontrado com sucesso!",
                Success = true,
                Data = allUsers
            });
        }



    }

}
