using Api.Util;
using Api.ViewModel;
using AutoMapper;
using Core.Exceptions;
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
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

    }
}
